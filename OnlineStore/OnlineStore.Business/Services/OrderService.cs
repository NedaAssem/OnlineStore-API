using OnlineStore.Business.DTOs.Orders;
using OnlineStore.Business.Enums;
using OnlineStore.Business.Interfaces;
using OnlineStore.Data.Entities;
using OnlineStore.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;

        public OrderService(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            var items = await _orderRepo.GetAllAsync();
            return items.Select(o => new OrderDto
            {
                OrderId = o.OrderId,
                CustomerId = o.CustomerId,
                Status = Enum.TryParse<OrderStatus>(o.Status, out var s) ? s : OrderStatus.Pending,
                CreatedAt = o.OrderDate,
                TotalAmount = o.TotalAmount,
            });
        }

        public async Task<OrderDto?> GetOrderByIdAsync(int id)
        {
            var o = await _orderRepo.GetByIdAsync(id);
            if (o == null) return null;
            return new OrderDto
            {
                OrderId = o.OrderId,
                CustomerId = o.CustomerId,
                Status = Enum.TryParse<OrderStatus>(o.Status, out var s) ? s : OrderStatus.Pending,
                CreatedAt = o.OrderDate,
                TotalAmount = o.TotalAmount,
            };
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersByCustomerIdAsync(int customerId)
        {
            var items = await _orderRepo.GetOrdersByCustomerId(customerId);
            return items.Select(o => new OrderDto
            {
                OrderId = o.OrderId,
                CustomerId = o.CustomerId,
                Status = Enum.TryParse<OrderStatus>(o.Status, out var s) ? s : OrderStatus.Pending,
                CreatedAt = o.OrderDate,
                TotalAmount = o.TotalAmount,
            });
        }

        public async Task<OrderDto> CreateOrderAsync(CreateOrderDto orderDto)
        {
           
            var entity = new Order
            {
                CustomerId = orderDto.CustomerId,
                OrderDate = DateTime.UtcNow,
                Status = OrderStatus.Pending.ToString(),
                
                OrderItems = new List<OrderItem>(),
                
            };

            foreach (var itemDto in orderDto.OrderItems)
            {
                var orderItem = new OrderItem
                {
                    ProductId = itemDto.ProductId,
                    Quantity = itemDto.Quantity,
                    Price = itemDto.UnitPrice,
                    TotalItemsPrice = itemDto.Quantity * itemDto.UnitPrice,
                   
                };

                entity.TotalAmount += orderItem.TotalItemsPrice;
                entity.OrderItems.Add(orderItem);

            };
            
            await _orderRepo.AddAsync(entity);
            await _orderRepo.SaveChangesAsync();

            return new OrderDto
            {
                OrderId = entity.OrderId,
                CustomerId = entity.CustomerId,
                Status = OrderStatus.Pending,
                CreatedAt = entity.OrderDate,
                TotalAmount = entity.TotalAmount,
               
            };
        }

        public async Task<OrderDto?> UpdateOrderStatusAsync(int id, UpdateOrderStatusDto dto)
        {
            var entity = await _orderRepo.GetByIdAsync(id);
            if (entity == null) return null;

            entity.Status = dto.Status.ToString();
            _orderRepo.Update(entity);
            await _orderRepo.SaveChangesAsync();

            return new OrderDto
            {
                OrderId = entity.OrderId,
                CustomerId = entity.CustomerId,
                Status = dto.Status,
                CreatedAt = entity.OrderDate,
                TotalAmount = entity.TotalAmount,
            };
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var entity = await _orderRepo.GetByIdAsync(id);
            if (entity == null) return false;

            _orderRepo.Delete(entity);
            await _orderRepo.SaveChangesAsync();
            return true;
        }
       
    }
}

using OnlineStore.Business.DTOs.OrderItems;
using OnlineStore.Business.Interfaces;
using OnlineStore.Data.Entities;
using OnlineStore.Data.Interfaces;
using OnlineStore.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Business.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepo;

        public OrderItemService(IOrderItemRepository orderItemRepo)
        {
            _orderItemRepo = orderItemRepo;
        }

        public async Task<IEnumerable<OrderItemDto>> GetAllAsync()
        {
            var items = await _orderItemRepo.GetAllAsync();
            return items.Select(i => new OrderItemDto
            {

                OrderId = i.OrderId,
                ProductId = i.ProductId,
                Quantity = i.Quantity
            });
        }

        public async Task<OrderItemDto?> GetByIdAsync(int id)
        {
            var i = await _orderItemRepo.GetByIdAsync(id);
            if (i == null) return null;
            return new OrderItemDto
            {

                OrderId = i.OrderId,
                ProductId = i.ProductId,
                Quantity = i.Quantity,
                UnitPrice=i.Price,
                TotalItemPrice=i.TotalItemsPrice

            };
        }



        public async Task<OrderItemDto> CreateAsync(CreateOrderItemDto dto)
        {
            var entity = new OrderItem
            {
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                // OrderId must be set by caller or via separate method
            };

            await _orderItemRepo.AddAsync(entity);
            await _orderItemRepo.SaveChangesAsync();

            return new OrderItemDto
            {

                OrderId = entity.OrderId,
                ProductId = entity.ProductId,
                Quantity = entity.Quantity
            };
        }



        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _orderItemRepo.GetByIdAsync(id);
            if (entity == null) return false;

            _orderItemRepo.Delete(entity);
            await _orderItemRepo.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<OrderItemDto>> GetItemsByOrderIdAsync(int orderId)
        {
            var list = await _orderItemRepo.GetItemsByOrderId(orderId);
            return list.Select(i => new OrderItemDto
            {

                OrderId = i.OrderId,
                ProductId = i.ProductId,
                Quantity = i.Quantity,
                UnitPrice = i.Price,
                TotalItemPrice = i.TotalItemsPrice
            });
        }
       
    }
}

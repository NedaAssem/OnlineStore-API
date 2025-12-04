using OnlineStore.Business.DTOs.OrderItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Business.Interfaces
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItemDto>> GetAllAsync();
        Task<OrderItemDto> GetByIdAsync(int id);

        Task<OrderItemDto> CreateAsync(CreateOrderItemDto dto);
        
        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<OrderItemDto>> GetItemsByOrderIdAsync(int orderId);
    }
}

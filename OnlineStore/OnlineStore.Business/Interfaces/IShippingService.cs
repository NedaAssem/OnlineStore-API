using OnlineStore.Business.DTOs.Shippings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Business.Interfaces
{
    public interface IShippingService
    {
        Task<IEnumerable<ShippingDto>> GetAllAsync();
        Task<ShippingDto> GetByIdAsync(int id);
       
        Task<ShippingDto> CreateAsync(CreateShippingDto dto);
        Task<ShippingDto> UpdateStatusAsync(int id,UpdateShippingStatusDto dto);
        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<ShippingDto>> GetShippingByOrderIdAsync(int orderId);
    }
}

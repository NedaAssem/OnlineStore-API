using OnlineStore.Business.DTOs.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Business.Interfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentDto>> GetAllAsync();
        Task<PaymentDto> GetByIdAsync(int id);
       
        Task<PaymentDto> CreateAsync(CreatePaymentDto dto);
        
        Task<bool> DeleteAsync(int id);
       

        Task<IEnumerable<PaymentDto>> GetPaymentsByOrderIdAsync(int orderId);
    }
}

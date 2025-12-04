using OnlineStore.Business.DTOs.Payments;
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
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepo;

        public PaymentService(IPaymentRepository paymentRepo)
        {
            _paymentRepo = paymentRepo;
        }

        public async Task<IEnumerable<PaymentDto>> GetAllAsync()
        {
            var items = await _paymentRepo.GetAllAsync();
            return items.Select(p => new PaymentDto
            {
                PaymentId = p.PaymentId,
                OrderId = p.OrderId,
                Method = Enum.TryParse<PaymentMethod>(p.PaymentMethod, out var m) ? m : PaymentMethod.Cash,
                //Status = Enum.TryParse<PaymentStatus>(p.Status, out var s) ? s : PaymentStatus.Pending,
                Amount = p.Amount
            });
        }

        public async Task<PaymentDto?> GetByIdAsync(int id)
        {
            var p = await _paymentRepo.GetByIdAsync(id);
            if (p == null) return null;
            return new PaymentDto
            {
                PaymentId = p.PaymentId,
                OrderId = p.OrderId,
                Method = Enum.TryParse<PaymentMethod>(p.PaymentMethod, out var m) ? m : PaymentMethod.Cash,
                //Status = Enum.TryParse<PaymentStatus>(p.Status, out var s) ? s : PaymentStatus.Pending,
                Amount = p.Amount
            };
        }

        public async Task<PaymentDto> CreateAsync(CreatePaymentDto dto)
        {
            var entity = new Payment
            {
                OrderId = dto.OrderId,
                PaymentMethod = dto.Method.ToString(),
                Amount = dto.Amount,
                //Status = PaymentStatus.Pending.ToString(),
                TransactionDate = DateTime.UtcNow
            };

            await _paymentRepo.AddAsync(entity);
            await _paymentRepo.SaveChangesAsync();

            return new PaymentDto
            {
                PaymentId = entity.PaymentId,
                OrderId = entity.OrderId,
                Method = dto.Method,
                //Status = PaymentStatus.Pending,
                Amount = entity.Amount
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var e = await _paymentRepo.GetByIdAsync(id);
            if (e == null) return false;
            _paymentRepo.Delete(e);
            await _paymentRepo.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<PaymentDto>> GetPaymentsByOrderIdAsync(int orderId)
        {
            var list = await _paymentRepo.GetPaymentsByOrderId(orderId);
            return list.Select(p => new PaymentDto
            {
                PaymentId = p.PaymentId,
                OrderId = p.OrderId,
                Method = Enum.TryParse<PaymentMethod>(p.PaymentMethod, out var m) ? m : PaymentMethod.Cash,
                // Status = Enum.TryParse<PaymentStatus>(p.Status, out var s) ? s : PaymentStatus.Pending,
                Amount = p.Amount
            });
        }
       
    }
}

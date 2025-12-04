using OnlineStore.Business.DTOs.Shippings;
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
    public class ShippingService : IShippingService
    {
        private readonly IShippingRepository _shippingRepo;

        public ShippingService(IShippingRepository shippingRepo)
        {
            _shippingRepo = shippingRepo;
        }

        public async Task<IEnumerable<ShippingDto>> GetAllAsync()
        {
            var items = await _shippingRepo.GetAllAsync();
            return items.Select(s => new ShippingDto
            {
                ShippingId = s.ShippingId,
                OrderId = s.OrderId,
                Status = Enum.TryParse<ShippingStatus>(s.ShippingStatus, out var st) ? st : ShippingStatus.NotShipped,
                EstimatedDeliveryDate = s.EstimatedDeliveryDate,
                ActualDeliveryDate = s.ActualDeliveryDate
            });
        }

        public async Task<ShippingDto?> GetByIdAsync(int id)
        {
            var s = await _shippingRepo.GetByIdAsync(id);
            if (s == null) return null;
            return new ShippingDto
            {
                ShippingId = s.ShippingId,
                OrderId = s.OrderId,
                Status = Enum.TryParse<ShippingStatus>(s.ShippingStatus, out var st) ? st : ShippingStatus.NotShipped,
                EstimatedDeliveryDate = s.EstimatedDeliveryDate,
                ActualDeliveryDate = s.ActualDeliveryDate
            };
        }



        public async Task<ShippingDto> CreateAsync(CreateShippingDto dto)
        {
            var entity = new Shipping
            {
                OrderId = dto.OrderId,
                ShippingStatus = dto.Status.ToString(),
                EstimatedDeliveryDate = dto.EstimatedDeliveryDate,
                CarrierName = dto.CarrierName,
                TrackingNumber = dto.TrackingNumber
               
            };

            await _shippingRepo.AddAsync(entity);
            await _shippingRepo.SaveChangesAsync();

            return new ShippingDto
            {
                ShippingId = entity.ShippingId,
                OrderId = entity.OrderId,
                Status = Enum.TryParse<ShippingStatus>(entity.ShippingStatus, out var st) ? st : ShippingStatus.NotShipped,
                EstimatedDeliveryDate = entity.EstimatedDeliveryDate,
                
            };
        }

        public async Task<ShippingDto?> UpdateStatusAsync(int id, UpdateShippingStatusDto dto)
        {
            var entity = await _shippingRepo.GetByIdAsync(id);
            if (entity == null) return null;

            entity.ShippingStatus = dto.Status.ToString();
            _shippingRepo.Update(entity);
            await _shippingRepo.SaveChangesAsync();

            return new ShippingDto
            {
                ShippingId = entity.ShippingId,
                OrderId = entity.OrderId,
                Status = dto.Status,
                EstimatedDeliveryDate = entity.EstimatedDeliveryDate,
                ActualDeliveryDate = entity.ActualDeliveryDate
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var e = await _shippingRepo.GetByIdAsync(id);
            if (e == null) return false;
            _shippingRepo.Delete(e);
            await _shippingRepo.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ShippingDto>> GetShippingByOrderIdAsync(int orderId)
        {
            var list = await _shippingRepo.GetShippingByOrderId(orderId);
            return list.Select(s => new ShippingDto
            {
                ShippingId = s.ShippingId,
                OrderId = s.OrderId,
                Status = Enum.TryParse<ShippingStatus>(s.ShippingStatus, out var st) ? st : ShippingStatus.NotShipped,
                EstimatedDeliveryDate = s.EstimatedDeliveryDate,
                ActualDeliveryDate = s.ActualDeliveryDate
            });
        }
       
    }
}

using OnlineStore.Business.DTOs.Customers;
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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepo;

        public CustomerService(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var items = await _customerRepo.GetAllAsync();
            return items.Select(c => new CustomerDto
            {
                CustomerId = c.CustomerId,
                FullName = c.Name,
                Email = c.Email
            });
        }

        public async Task<CustomerDto> GetByIdAsync(int id)
        {
            var c = await _customerRepo.GetByIdAsync(id);
            if (c == null) return null;
            return new CustomerDto
            {
                CustomerId = c.CustomerId,
                FullName = c.Name,
                Email = c.Email
            };
        }



        public async Task<CustomerDto> CreateAsync(CreateCustomerDto dto)
        {
            var entity = new Customer
            {
                Name = dto.FullName,
                Email = dto.Email,
                Phone= dto.Phone,
                Address = dto.Address,
                Username=dto.Username,
                Password=dto.Password,
            };

            await _customerRepo.AddAsync(entity);
            await _customerRepo.SaveChangesAsync();

            return new CustomerDto
            {
                CustomerId = entity.CustomerId,
                FullName = entity.Name,
                Email = entity.Email
            };
        }
        public async Task<CustomerDto?> UpdateAsync(int id, UpdateCustomerDto dto)
        {
            var entity = await _customerRepo.GetByIdAsync(id);
            if (entity == null) return null;

            entity.Name = dto.FullName;
            entity.Email = dto.Email;

            _customerRepo.Update(entity);
            await _customerRepo.SaveChangesAsync();

            return new CustomerDto
            {
                CustomerId = entity.CustomerId,
                FullName = entity.Name,
                Email = entity.Email
            };
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _customerRepo.GetByIdAsync(id);
            if (entity == null) return false;

            _customerRepo.Delete(entity);
            await _customerRepo.SaveChangesAsync();
            return true;
        }


        public async Task<bool> EmailExists(string email)
        {
            return await _customerRepo.EmailExists(email);
        }

    }


}

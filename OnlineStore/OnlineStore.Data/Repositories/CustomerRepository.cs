using Microsoft.EntityFrameworkCore;
using OnlineStore.Data.Context;
using OnlineStore.Data.Entities;
using OnlineStore.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(OnlineStoreDbContext context) : base(context) { }

        public async Task<bool> EmailExists(string email)
        {
            return await _context.Set<Customer>()
                                 .AnyAsync(c => c.Email == email);
        }
    }
}

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
    public class ShippingRepository : Repository<Shipping>, IShippingRepository
    {
        public ShippingRepository(OnlineStoreDbContext context) : base(context) { }

        public async Task<IEnumerable<Shipping>> GetShippingByOrderId(int orderId)
        {
            return await _context.Set<Shipping>()
                                 .Where(s => s.OrderId == orderId)
                                 .ToListAsync();
        }
    }
}

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
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(OnlineStoreDbContext context) : base(context) { }

        public async Task<IEnumerable<OrderItem>> GetItemsByOrderId(int orderId)
        {
            return await _context.Set<OrderItem>()
                                 .Where(i => i.OrderId == orderId)
                                 .ToListAsync();
        }
    }
}

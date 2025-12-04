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
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(OnlineStoreDbContext context) : base(context) { }

        public async Task<IEnumerable<Payment>> GetPaymentsByOrderId(int orderId)
        {
            return await _context.Set<Payment>()
                                 .Where(p => p.OrderId == orderId)
                                 .ToListAsync();
        }
    }
}

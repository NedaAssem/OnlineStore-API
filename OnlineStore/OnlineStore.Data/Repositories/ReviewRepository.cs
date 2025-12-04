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
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(OnlineStoreDbContext context) : base(context) { }

        public async Task<IEnumerable<Review>> GetReviewsByProductId(int productId)
        {
            return await _context.Set<Review>()
                                 .Where(r => r.ProductId == productId)
                                 .ToListAsync();
        }
    }
}

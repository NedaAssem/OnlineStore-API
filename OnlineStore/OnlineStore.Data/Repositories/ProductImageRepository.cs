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
    public class ProductImageRepository : Repository<ProductImage>, IProductImageRepository
    {
        public ProductImageRepository(OnlineStoreDbContext context) : base(context) { }

        public async Task<IEnumerable<ProductImage>> GetByProductId(int productId)
        {
            return await _context.Set<ProductImage>()
                                 .Where(img => img.ProductId == productId)
                                 .ToListAsync();
        }
    }
}

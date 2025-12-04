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
    public class ProductCatalogRepository : Repository<ProductCatalog>, IProductCatalogRepository
    {
        public ProductCatalogRepository(OnlineStoreDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<ProductCatalog>> GetByCategoryId(int categoryId)
        {
            return await _context.Set<ProductCatalog>()
                                 .Where(p => p.CategoryId == categoryId)
                                 .ToListAsync();
        }


    }
}

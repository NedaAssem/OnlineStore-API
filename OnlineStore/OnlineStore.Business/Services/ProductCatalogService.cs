using OnlineStore.Business.DTOs.Products;
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
    public class ProductCatalogService : IProductCatalogService
    {
        private readonly IProductCatalogRepository _productRepo;

        public ProductCatalogService(IProductCatalogRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var items = await _productRepo.GetAllAsync();
            return items.Select(p => new ProductDto
            {
                ProductId = p.ProductId,
                Name = p.ProductName,
                Description = p.Description,
                Price = p.Price,
                CategoryId = p.CategoryId
            });
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var item = await _productRepo.GetByIdAsync(id);
            if (item == null) return null;
            return new ProductDto
            {
                ProductId = item.ProductId,
                Name = item.ProductName,
                Description = item.Description,
                Price = item.Price,
                CategoryId = item.CategoryId
            };
        }

        public async Task<IEnumerable<ProductDto>> GetByCategoryIdAsync(int categoryId)
        {
            var items = await _productRepo.GetByCategoryId(categoryId);
            return items.Select(p => new ProductDto
            {
                ProductId = p.ProductId,
                Name = p.ProductName,
                Description = p.Description,
                Price = p.Price,
                CategoryId = p.CategoryId
            });
        }

        public async Task<ProductDto> CreateProductAsync(CreateProductDto dto)
        {
            var entity = new ProductCatalog
            {
                ProductName = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                CategoryId = dto.CategoryId
            };
            await _productRepo.AddAsync(entity);
            await _productRepo.SaveChangesAsync();

            return new ProductDto
            {
                ProductId = entity.ProductId,
                Name = entity.ProductName,
                Description = entity.Description,
                Price = entity.Price,
                CategoryId = entity.CategoryId
            };
        }

        public async Task<ProductDto> UpdateProductAsync(int id, UpdateProductDto dto)
        {
            var entity = await _productRepo.GetByIdAsync(id);
            if (entity == null) return null;

            entity.ProductName = dto.Name;
            entity.Description = dto.Description;
            entity.Price = dto.Price;
            entity.CategoryId = dto.CategoryId;

            _productRepo.Update(entity);
            await _productRepo.SaveChangesAsync();

            return new ProductDto
            {
                ProductId = id,
                Name = entity.ProductName,
                Description = entity.Description,
                Price = entity.Price,
                CategoryId = entity.CategoryId
            };
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);

            if (product == null) return false;

            _productRepo.Delete(product);
            await _productRepo.SaveChangesAsync();
            return true;
        }
        
    }
}

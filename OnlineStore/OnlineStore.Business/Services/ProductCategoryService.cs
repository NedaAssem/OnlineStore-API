using OnlineStore.Business.DTOs.Categories;
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
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepo;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepo)
        {
            _productCategoryRepo = productCategoryRepo;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var items = await _productCategoryRepo.GetAllAsync();
            return items.Select(c => new CategoryDto
            {
                CategoryId = c.CategoryId,
                Name = c.CategoryName
            });

        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var item = await _productCategoryRepo.GetByIdAsync(id);
            if (item == null) return null;
            return new CategoryDto
            {
                CategoryId = item.CategoryId,
                Name = item.CategoryName
            };
        }



        public async Task<CategoryDto> CreateAsync(CreateCategoryDto dto)
        {
            var entity = new ProductCategory
            {
                CategoryName = dto.Name
            };


            await _productCategoryRepo.AddAsync(entity);
            await _productCategoryRepo.SaveChangesAsync();

            return new CategoryDto
            {
                CategoryId = entity.CategoryId,
                Name = dto.Name
            };
        }

        public async Task<CategoryDto> UpdateAsync(int id, UpdateCategoryDto dto)
        {
            
            var productCategory = await _productCategoryRepo.GetByIdAsync(id);
            if (productCategory == null) return null;
            var entity = new ProductCategory
            {
                CategoryId = id,
                CategoryName = dto.Name,
            };

            _productCategoryRepo.Update(entity);
            await _productCategoryRepo.SaveChangesAsync();

            return new CategoryDto
            {
                CategoryId = entity.CategoryId,
                Name = dto.Name
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var productCategory = await _productCategoryRepo.GetByIdAsync(id);
            if (productCategory == null) return false;

            _productCategoryRepo.Delete(productCategory);
            await _productCategoryRepo.SaveChangesAsync();

            return true;

        }
       
    }
}

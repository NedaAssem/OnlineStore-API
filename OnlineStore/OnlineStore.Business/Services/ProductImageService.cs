using OnlineStore.Business.DTOs.ProductImage;
using OnlineStore.Business.Interfaces;
using OnlineStore.Data.Entities;
using OnlineStore.Data.Interfaces;

using OnlineStore.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OnlineStore.Business.Services
{
    public class ProductImageService : IProductImageService
    {
        private readonly IProductImageRepository _productImageRepo;
       
        public ProductImageService(IProductImageRepository productImageRepo)
        {
            _productImageRepo = productImageRepo;
           
        }
       
      
              
           
        public async Task<IEnumerable<ProductImageDto>> GetAllAsync()
        {
            var items= await _productImageRepo.GetAllAsync();
            return items.Select(x => new ProductImageDto
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                ImageOrder = x.ImageOrder,
                ProductId = x.ProductId
            });
        }

        public async Task<ProductImageDto> GetByIdAsync(int id)
        {
            var item= await _productImageRepo.GetByIdAsync(id);
            if (item == null) return null;
            return new ProductImageDto
            {
                Id = item.Id,
                ImageUrl = item.ImageUrl,
                ImageOrder = item.ImageOrder,
                ProductId = item.ProductId
            };
        }



        public async Task<ProductImageDto> CreateAsync(string dbPath,createProductImageDto productImageDto)
        {
            var productImage = new ProductImage
            {
                ImageUrl = dbPath,
                ImageOrder = productImageDto.ImageOrder,
                ProductId = productImageDto.ProductId
            };

            await _productImageRepo.AddAsync(productImage);
            await _productImageRepo.SaveChangesAsync();
            return new ProductImageDto
            {
                Id = productImage.Id,
                ImageUrl = productImage.ImageUrl,
                ImageOrder = productImage.ImageOrder,
                ProductId = productImage.ProductId
            };
        }

        public async Task<ProductImageDto> UpdateAsync(int id,UpdateProductImageDto dto)
        {
            var entity =await _productImageRepo.GetByIdAsync(id);
            if (entity == null) return null;

            entity.ImageOrder = dto.ImageOrder;
           


            _productImageRepo.Update(entity);
            await _productImageRepo.SaveChangesAsync();

            return new ProductImageDto
            {
                Id = entity.Id,
                ImageUrl = entity.ImageUrl,
                ImageOrder = entity.ImageOrder,
                ProductId = entity.ProductId
            };
        }

        public async Task<string> DeleteAsync(int id)
        {
            var productImage = await _productImageRepo.GetByIdAsync(id);
            if (productImage == null) return string.Empty;

            string URL = productImage.ImageUrl;

            _productImageRepo.Delete(productImage);
            await _productImageRepo.SaveChangesAsync();
            return URL;
            
        }

        public async Task<IEnumerable<ProductImageDto>> GetByProductId(int productId)
        {
            var items =await _productImageRepo.GetByProductId(productId);
            return items.Select(x => new ProductImageDto
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                ImageOrder = x.ImageOrder,
                ProductId = productId
            });
        }
    }
}

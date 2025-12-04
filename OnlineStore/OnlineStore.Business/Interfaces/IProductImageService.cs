using OnlineStore.Business.DTOs.ProductImage;
using OnlineStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Business.Interfaces
{
    public interface IProductImageService
    {
        Task<IEnumerable<ProductImageDto>> GetAllAsync();
        Task<ProductImageDto> GetByIdAsync(int id);

        Task<ProductImageDto> CreateAsync(string path,createProductImageDto img);
        Task<ProductImageDto> UpdateAsync(int id,UpdateProductImageDto img);
        Task<string> DeleteAsync(int id);

        Task<IEnumerable<ProductImageDto>> GetByProductId(int productId);

       
    }
}

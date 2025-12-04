using OnlineStore.Business.DTOs.Reviews;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Business.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDto>> GetAllAsync();
        Task<ReviewDto> GetByIdAsync(int id);
       
        Task<ReviewDto> CreateAsync(CreateReviewDto dto);
       
        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<ReviewDto>> GetReviewsByProductIdAsync(int productId);
    }
}

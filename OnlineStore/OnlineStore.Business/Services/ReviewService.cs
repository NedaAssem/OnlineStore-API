using OnlineStore.Business.DTOs.Reviews;
using OnlineStore.Business.Enums;
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
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepo;

        public ReviewService(IReviewRepository reviewRepo)
        {
            _reviewRepo = reviewRepo;
        }

        public async Task<IEnumerable<ReviewDto>> GetAllAsync()
        {
            var items = await _reviewRepo.GetAllAsync();
            return items.Select(r => new ReviewDto
            {
                ReviewId = r.ReviewId,
                ProductId = r.ProductId,
                Rating = r.Rating,
                Comment = r.ReviewText
            });
        }
        public async Task<ReviewDto> GetByIdAsync(int id)
        {
            var item = await _reviewRepo.GetByIdAsync(id);
            if (item == null) return null;
            return new ReviewDto
            {
                ReviewId = item.ReviewId,
                ProductId = item.ProductId,
                Rating = item.Rating,
                Comment = item.ReviewText
            };
        }



        public async Task<ReviewDto> CreateAsync(CreateReviewDto dto)
        {
            var entity = new Review
            {
                ProductId = dto.ProductId,
                CustomerId=dto.CustomerId,
                Rating = dto.Rating,
                ReviewText = dto.Comment,
                ReviewDate=DateTime.Now
                
            };

            await _reviewRepo.AddAsync(entity);
            await _reviewRepo.SaveChangesAsync();

            return new ReviewDto
            {
                ReviewId = entity.ReviewId,
                ProductId = entity.ProductId,
                Rating = entity.Rating,
                Comment = entity.ReviewText
            };
        }



        public async Task<bool> DeleteAsync(int id)
        {
            var e = await _reviewRepo.GetByIdAsync(id);
            if (e == null) return false;
            _reviewRepo.Delete(e);
            await _reviewRepo.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ReviewDto>> GetReviewsByProductIdAsync(int productId)
        {
            var list = await _reviewRepo.GetReviewsByProductId(productId);
            return list.Select(r => new ReviewDto
            {
                ReviewId = r.ReviewId,
                ProductId = r.ProductId,
                Rating = r.Rating,
                Comment = r.ReviewText
            });
        }
       
    }
}

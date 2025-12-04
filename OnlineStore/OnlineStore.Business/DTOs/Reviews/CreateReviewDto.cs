using OnlineStore.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Business.DTOs.Reviews
{
    public class CreateReviewDto
    {
        public int ProductId { get; set; }

        public int? CustomerId { get; set; }
        public decimal Rating { get; set; }
        public string? Comment { get; set; }
    }
}

using OnlineStore.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Business.DTOs.Reviews
{
    public class ReviewDto
    {
        public int ReviewId { get; set; }
        public int? ProductId { get; set; }
        public decimal Rating { get; set; }
        public string? Comment { get; set; }
    }
}

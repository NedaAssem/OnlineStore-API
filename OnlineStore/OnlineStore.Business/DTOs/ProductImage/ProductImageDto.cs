using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Business.DTOs.ProductImage
{
    public class ProductImageDto
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; } = null!;

        public short ImageOrder { get; set; }

        public int ProductId { get; set; }
    }
}

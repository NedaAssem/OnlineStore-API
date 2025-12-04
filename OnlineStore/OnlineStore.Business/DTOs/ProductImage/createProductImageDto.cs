using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Business.DTOs.ProductImage
{
    public class createProductImageDto
    {
        
        public string ImageURL { get; set; }
        public short ImageOrder { get; set; }

        public int ProductId { get; set; }
    }
}

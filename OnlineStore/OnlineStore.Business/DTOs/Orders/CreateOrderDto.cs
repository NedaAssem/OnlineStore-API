using OnlineStore.Business.DTOs.OrderItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Business.DTOs.Orders
{
    public class CreateOrderDto
    {
        public int CustomerId { get; set; }
        

        public ICollection< CreateOrderItemDto> OrderItems { get; set; }

       
    }
}

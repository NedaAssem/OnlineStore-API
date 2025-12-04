using OnlineStore.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Business.DTOs.Orders
{
    public class UpdateOrderStatusDto
    {
        public OrderStatus Status { get; set; }
       
    }
}

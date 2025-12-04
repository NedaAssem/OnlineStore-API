using OnlineStore.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Business.DTOs.Shippings
{
    public class CreateShippingDto
    {
        public int OrderId { get; set; }
        public ShippingStatus Status { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }

        public string CarrierName { get; set; } 

        public string TrackingNumber { get; set; } 

    }
}

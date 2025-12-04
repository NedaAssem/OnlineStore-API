using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Business.Enums
{
    public enum ShippingStatus
    {
        NotShipped = 1,
        InTransit = 2,
        OutForDelivery = 3,
        Delivered = 4,
        Lost = 5
    }
}

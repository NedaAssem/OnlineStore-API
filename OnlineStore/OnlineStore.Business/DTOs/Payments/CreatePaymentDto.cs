using OnlineStore.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Business.DTOs.Payments
{
    public class CreatePaymentDto
    {
        public int OrderId { get; set; }
        public PaymentMethod Method { get; set; }
        public decimal Amount { get; set; }
    }
}

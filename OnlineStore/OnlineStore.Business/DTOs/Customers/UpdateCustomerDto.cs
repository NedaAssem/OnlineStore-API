using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Business.DTOs.Customers
{
    public class UpdateCustomerDto
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}

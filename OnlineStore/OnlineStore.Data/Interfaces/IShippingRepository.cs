using OnlineStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Data.Interfaces
{
    public interface IShippingRepository : IRepository<Shipping>
    {
        Task<IEnumerable<Shipping>> GetShippingByOrderId(int orderId);
    }
}

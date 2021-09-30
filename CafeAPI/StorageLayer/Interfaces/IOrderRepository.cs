using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageLayer.Interfaces
{
    public interface IOrderRepository
    {
        Task<ViewModelOrder> PlaceOrderAsync(ViewModelOrder vmo);
        Task<ViewModelOrder> OrderListAsync(ViewModelOrder vmo);
    }
}

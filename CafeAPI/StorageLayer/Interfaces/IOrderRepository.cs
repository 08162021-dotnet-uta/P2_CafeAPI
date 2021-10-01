using DatabaseLayer;
using ModelsLayer.EfModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageLayer.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<ViewModelOrder>> PlaceOrderAsync(ViewModelOrder vmo);
        Task<List<ViewModelOrder>> OrderListAsync(int customerId);
    }
}

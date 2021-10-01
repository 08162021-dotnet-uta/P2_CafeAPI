using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageLayer.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<ViewModelOrderItem> AddOrderItemAsync(ViewModelOrderItem vmoi);
    }
}

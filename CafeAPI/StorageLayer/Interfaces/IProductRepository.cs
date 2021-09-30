using ModelsLayer.EfModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageLayer.Interfaces
{
    public interface IProductRepository
    {
        Task<Boolean> outOfStockAsync(string id);
        void reduceStock(string id);
    }
}

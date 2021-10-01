using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageLayer.Interfaces
{
    public interface IProductRepository
    {
        List<ViewModelProduct> Products() { throw new NotImplementedException(); }
        Task<ViewModelProduct> GetProductAsync(string id) { throw new NotImplementedException(); }
    }
}

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
        Task<ViewModelProduct> AddProductAsync(ViewModelProduct vmp);
        //Task<ViewModelProduct> ProductListAsync(ViewModelProduct vmp);
        List<ViewModelProduct> Products() { throw new NotImplementedException(); }
        Task<ViewModelProduct> GetProductAsync(string id) { throw new NotImplementedException(); }
        Task<ViewModelProduct> PostProductAsync(ViewModelProduct vmp) { throw new NotFiniteNumberException(); }
    }
}

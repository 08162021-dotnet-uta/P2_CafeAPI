using DatabaseLayer;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.EfModels;
using StorageLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageLayer
{
    public class ProductRepository : IProductRepository
    {
        // Step 1 of Dependency Injection - create a  private instance of the dependency
        private readonly testprojectContext _context;
        // Step 2 of DI - call for an instance from the DI system in the constructor.
        public ProductRepository(testprojectContext context)
        {
            _context = context;
        }


        public List<ViewModelProduct> Products()
        {
            List<Product> products = _context.Products.FromSqlRaw<Product>("select * from Product").ToList();

            List<ViewModelProduct> vmp = new List<ViewModelProduct>();
            foreach (Product p in products)
            {
                vmp.Add(ModelMapper.ProductToViewModelProduct(p));
            }

            return vmp;
        }
    }
}

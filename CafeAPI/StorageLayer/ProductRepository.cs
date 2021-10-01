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

        /// <summary>
        /// This method returns the list of all products from the Database
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// This method takes a string Id and returns a product with that Id if found,
        /// otherwise, return null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ViewModelProduct> GetProductAsync(string id)
        {
            Product p = await _context.Products.FromSqlRaw<Product>("select * from Product where Id = {0}", id).FirstOrDefaultAsync();

            if (p == null) return null;
            ViewModelProduct p1 = ModelMapper.ProductToViewModelProduct(p);
            return p1;
        }

        /// <summary>
        /// This method takes a ViewModelProduct and inserts it to the DB, 
        /// if successfull, returns the same product, otherwise returns null;
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public async Task<ViewModelProduct> PostProductAsync(ViewModelProduct p)
        {
            Product p1 = ModelMapper.ViewModelProductToProduct(p);
            int i = await _context.Database.ExecuteSqlRawAsync("INSERT INTO Product (Id, Name, Description, Price, Inventory) VALUES ({0},{1}),{2},{3},{4}", p.Id, p.Name, p.Description, p.Price, p.Inventory);// default is NULL
            if (i != 1) return null;
            return await GetProductAsync(p.Id);
        }
    }
}

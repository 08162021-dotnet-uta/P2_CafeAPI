using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageLayer.Interfaces;
using DatabaseLayer;
using ModelsLayer.EfModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace StorageLayer.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly testprojectContext _context;

        public ProductRepository(testprojectContext context)
            { _context = context; }

        public async Task<Boolean> outOfStockAsync(string id)
        {
            Product product = await _context.Products.FindAsync(id);
            if (product.Inventory > 0) return false; 
            else return true;
        }

        public void reduceStock(string id) 
        {
            _context.Database.ExecuteSqlRaw($"update Product set Inventory = Inventory - 1 where Id = {id}");
            _context.SaveChanges();
        }
    }
}

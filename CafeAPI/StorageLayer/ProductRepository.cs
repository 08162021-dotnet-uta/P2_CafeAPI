using DatabaseLayer;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.EfModels;
using StorageLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace StorageLayer
//{
//    //public class ProductRepository : IProductRepository
//    {
//        // Step1 of DI - create  privatre instance of the dependency
//        private readonly testprojectContext _context;

//        // step 2 of DI - call for an in stance from the DI system in your constructor.
//        public ProductRepository(testprojectContext context)
//        {
//            _context = context;
//        }

//        /// <summary>
//        /// This method will add a product to the product table in the DB
//        /// </summary>
//        /// <param name="vmp"></param>
//        /// <returns></returns>
//        //public async Task<ViewModelProduct> AddProductAsync(ViewModelProduct vmp)
//        //{
//        //    Product p1 = ModelMapper.ViewModelProductToProduct(vmp);
//        //    int p2 = await _context.Database.ExecuteSqlRawAsync("INSERT INTO Product (ProductId, Name, Price) VALUES ({0},{1},{2})", p1.ProductId, p1.Name, p1.Price);
//        //    if (p2 != 1) return null;
//        //    return Products();
//        //}

//        //public List<ViewModelProduct> Products()
//        //{
//        //    List<Product> products = _context.Products.FromSqlRaw<Product>("select * from Product").ToList();

//        //    List<ViewModelProduct> vmp = new List<ViewModelProduct>();
//        //    foreach (Product p in products)
//        //    {
//        //        vmp.Add(ModelMapper.ProductToViewModelProduct(p));
//        //    }

//        //    return vmp;
//        //}
//    }
//}

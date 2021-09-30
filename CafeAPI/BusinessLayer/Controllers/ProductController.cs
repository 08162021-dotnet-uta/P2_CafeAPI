using DatabaseLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using StorageLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productrepo;
        // Dependency Inversion - should not depend directly on the class, rather on the abstraction
        public ProductController(IProductRepository pr)
        {
            _productrepo = pr;
        }

        // GET: ProductController/products
        [HttpGet("list")]
        public List<ViewModelProduct> Details()
        {

            List<ViewModelProduct> products = _productrepo.Products();
            return products;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}

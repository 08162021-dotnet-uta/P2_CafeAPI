using DatabaseLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using StorageLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsLayer.EfModels;
using StorageLayer;

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

        /// <summary>
        /// This method takes a string Id and returns a product with that Id if found,
        /// otherwise returns Not Found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("detail/{id}")]
        public async Task<ActionResult<ViewModelProduct>> GetProductById(string id)
        {

            if (!ModelState.IsValid) return BadRequest();

            ViewModelProduct p = await _productrepo.GetProductAsync(id);
            if (p == null)
            {
                return NotFound();
            }

            return Ok(p);

        }

        [HttpPost("register")]
        public async Task<ActionResult<ViewModelProduct>> Create(ViewModelProduct p)
        {
            if (!ModelState.IsValid) return BadRequest();

            ViewModelProduct p1 = await _productrepo.PostProductAsync(p);
            if (p1 == null)
            {
                return NotFound();
            }
            return Created($"~product/{p1.Id}", p1);
        }
    }
}

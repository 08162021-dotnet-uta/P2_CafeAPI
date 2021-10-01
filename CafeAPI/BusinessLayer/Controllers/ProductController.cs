
﻿using DatabaseLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using StorageLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsLayer.EfModels;
using StorageLayer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BusinessLayer.Controllers
{
    [Route("[controller]")]
    [ApiController]
   
    public class ProductController : Controller
    {
        private readonly IProductRepository _productrepo;
        // Dependency Inversion - should not depend directly on the class, rather on the abstraction
        public ProductController(IProductRepository pr)
        {
            _productrepo = pr;
        }

        [HttpGet("outOfStock/{id}")]
        public async Task<ActionResult<Boolean>> Get(string id)
        {
            if (!ModelState.IsValid) return BadRequest();
            Boolean outOfStock = await _productrepo.outOfStockAsync(id);
            if (!outOfStock) _productrepo.reduceStock(id);
            return Ok(outOfStock);
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

        //// GET api/<ProductController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ProductController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ProductController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ProductController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}



    

        
    }
}

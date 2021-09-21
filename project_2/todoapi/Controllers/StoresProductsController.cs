using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _08162021batchDemoStore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project1.ModelsLayer.EfModels;
using Project1.StoreApplication.Storage.Models;
using DemoStoreBusinessLayer.Interfaces;



namespace Project1.StoreApplication.Storage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresProductsController : Controller
    {
        private readonly ICustomerRepository _storerepo;
        private readonly ILogger<StoresProductsController> _logger;

        public StoresProductsController(ICustomerRepository cr, ILogger<StoresProductsController> logger)
        {
            _storerepo = cr;
            _logger = logger;
        }
        // GET: CustomerController
       


        //private readonly Demo_08162021batchContext _context;

        //public StoresProductsController(Demo_08162021batchContext context)
        //{
        //    _context = context;
        //}

        // GET: api/StoresProducts
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<StoresProduct>>> GetStoresProducts()
        //{
        //    return await _context.StoresProducts.ToListAsync();
        //}

        //// GET: api/StoresProducts/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<StoresProduct>> GetStoresProduct(int id)
        //{
        //    var storesProduct = await _context.StoresProducts.FindAsync(id);

        //    if (storesProduct == null)
        //    {
        //        return NotFound();
        //    }

        //    return storesProduct;
        //}
     

  
                // GET: CustomerController/Create - this is the route for conventional routing 
                // Attribute routing involves using attributes to define the path
                [HttpPost("addtostorecart")]
        public async Task<ActionResult<ViewModelStoreProduct>> Create(ViewModelStoreProduct c)
        {
            Console.WriteLine(c);
            if (!ModelState.IsValid) return BadRequest();

            //ViewModelCustomer c = new ViewModelCustomer() { Fname = fname, Lname = lname };
            //send fname and lname into a method of the business layer to check the Db fo that guy/gal;
            ViewModelStoreProduct c1 = await _storerepo.addtoStoreCartAsync(c);
            if (c1 == null)
            {
                return NotFound();
            }
            Console.WriteLine(c1);

            return Created($"~StoreProduct/{c1.StoreProductId}", c1);
        }

        // GET: CustomerController/Details/5
        [HttpGet("Customerlist")]
        public async Task<List<ViewModelCustomer>> Details()
        {
            // call the business layer method to return list of customers
            //List<ViewModelCustomer> customers = await 
            Task<List<ViewModelCustomer>> customers = _storerepo.CustomerListAsync();
            //do stuff
            _logger.LogInformation("\n\nThere was a problem in the Customerlist method.\n\n");

            //do more stuff

            List<ViewModelCustomer> customers1 = await customers;
            return customers1;
        }
        // GET: CustomerController
        [HttpGet]
        public ActionResult Index()
        {
            //ViewModelCustomer obj = new ViewModelCustomer();
            return View();

        }
        // GET: CustomerController/Create - this is the route for conventional routing 
        // Attribute routing involves using attributes to define the path
        [HttpPut("customercreate/{id}")]
        public ActionResult Create(int id)
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5

        [HttpPut("customerupdate/{id}")]
        public ActionResult Edit(int id)
        {
            return View();
        }
        // GET: CustomerController/Delete/5
        [HttpGet("delete/{id}")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost("deleteidcollect")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // PUT: api/StoresProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutStoresProduct(int id, StoresProduct storesProduct)
        //{
        //    if (id != storesProduct.StoreProductId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(storesProduct).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!StoresProductExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/StoresProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<StoresProduct>> PostStoresProduct(StoresProduct storesProduct)
        //{
        //    _context.StoresProducts.Add(storesProduct);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetStoresProduct", new { id = storesProduct.StoreProductId }, storesProduct);
        //}

        //// DELETE: api/StoresProducts/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteStoresProduct(int id)
        //{
        //    var storesProduct = await _context.StoresProducts.FindAsync(id);
        //    if (storesProduct == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.StoresProducts.Remove(storesProduct);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool StoresProductExists(int id)
        //{
        //    return _context.StoresProducts.Any(e => e.StoreProductId == id);
        //}
    }
}

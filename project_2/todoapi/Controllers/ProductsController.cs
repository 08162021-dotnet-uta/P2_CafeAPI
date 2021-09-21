using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _08162021batchDemoStore;
using DemoStoreBusinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project1.ModelsLayer.EfModels;
using Project1.StoreApplication.Storage.Models;

namespace Project1.StoreApplication.Storage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
      //  private readonly Demo_08162021batchContext _context;
        private readonly ICustomerRepository _customerrepo;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ICustomerRepository cr, ILogger<ProductsController> logger)
        {
            _customerrepo = cr;
            _logger = logger;
        }
        // GET: CustomerController
        [HttpGet("index")]
        public ActionResult Index()
        {
            //ViewModelCustomer obj = new ViewModelCustomer();
            return View();

        }

        // GET: CustomerController/Details/5
        //[HttpGet("Productlist/{c}")]
        //public async Task<List<ViewModelProduct>> Detailsbyviewmodel(ViewModelsStore c)
        //{
        //    // call the business layer method to return list of customers
        //    //List<ViewModelCustomer> customers = await 
        //    Task<List<ViewModelProduct>> customers = _customerrepo.StoreProductListAsync(c);

        //    //do stuff
        //    _logger.LogInformation("\n\nThere was a problem in the ViewModelProduct Details method.\n\n");

        //    //do more stuff

        //    List<ViewModelProduct> customers1 = await customers;
        //    return customers1;
        //}

        // GET: CustomerController/Details/5
        [HttpGet("ProductsbyStore/{Storeid}")]
        public async Task<List<ViewModelProduct>> Details(int Storeid)
        {
            // call the business layer method to return list of customers
            //List<ViewModelCustomer> customers = await 
            ViewModelsStore c = new ViewModelsStore() { StoreId = Storeid };
            //Store hi = new ViewModelStoreProduct();
            Task<List<ViewModelProduct>> customers = _customerrepo.StoreProductListAsync(c);
            //do stuff
            _logger.LogInformation("\n\nThere was a problem in the TASKViewModelProduct Details in Controller method.\n\n");

            //do more stuff

            List<ViewModelProduct> customers1 = await customers;
            return customers1;
        }
        // GET: CustomerController/Details/5
        [HttpGet("pastordersbystore/{customerid}/{storeid}")]
        public async Task<List<ViewModelProduct>> DetailsPast(int customerid, int storeid)
        {
            // call the business layer method to return list of customers
            //List<ViewModelCustomer> customers = await 
            ViewModelCustomer c = new ViewModelCustomer() { CustomerId = customerid };
            ViewModelsStore s = new ViewModelsStore() { StoreId = storeid };
            //Store hi = new ViewModelStoreProduct();
            Task<List<ViewModelProduct>> productss = _customerrepo.getPastOrdersAsync(c,s);
            //do stuff
            _logger.LogInformation("\n\nThere was a problem in the ViewModelProduct Detailspast method.\n\n");

            //do more stuff

            List<ViewModelProduct> products1 = await productss;
            return products1;
        }

        //public ProductsController(Demo_08162021batchContext context)
        //{
        //    _context = context;
        //}

        // GET: api/Products
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        //{
        //    return await _context.Products.ToListAsync();
        //}

        // GET: api/Products/5
        //[HttpGet("getproduct/{id}")]
        //public async Task<ActionResult<Product>> GetProduct(int id)
        //{
        //    var product = await _context.Products.FindAsync(id);

        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return product;
        //}

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("putproduct/{id}")]
        //public async Task<IActionResult> PutProduct(int id, Product product)
        //{
        //    if (id != product.ProductId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(product).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProductExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost("postproduct/{product}")]
        //public async Task<ActionResult<Product>> PostProduct(Product product)
        //{
        //    _context.Products.Add(product);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        //}

        // DELETE: api/Products/5
        //[HttpDelete("delete/{id}")]
        //public async Task<IActionResult> DeleteProduct(int id)
        //{
        //    var product = await _context.Products.FindAsync(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Products.Remove(product);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool ProductExists(int id)
        //{
        //    return _context.Products.Any(e => e.ProductId == id);
        //}
    }
}

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
    [ApiController]
    [Route("[controller]")]
    public class StoresController : Controller
    {
        private readonly ICustomerRepository _storerepo;
        private readonly ILogger<StoresController> _logger;

        public StoresController(ICustomerRepository cr, ILogger<StoresController> logger)
        {
            _storerepo = cr;
            _logger = logger;
        }
        //private readonly Demo_08162021batchContext _context;

        //public StoresController(Demo_08162021batchContext context)
        //{
        //    _context = context;
        //}
        [HttpGet("index")]
        public ActionResult Index()
        {
            //ViewModelCustomer obj = new ViewModelCustomer();
            return View();

        }

        [HttpPut("storecreate/{id}")]
        public ActionResult Create(int id)
        {
            return View();
        }

        // GET: CustomerController/Details/5
        [HttpGet("/Stores/pastordersbystore/{storeid}")]
        public async Task<List<ViewModelAll>> DetailsPast( int storeid)
        {
            // call the business layer method to return list of customers
            //List<ViewModelCustomer> customers = await 
     
            ViewModelsStore s = new ViewModelsStore() { StoreId = storeid };
            //Store hi = new ViewModelStoreProduct();
            Task<List<ViewModelAll>> productss = _storerepo.getPastOrdersStoreAsync( s);
            //do stuff
            _logger.LogInformation("\n\nThere was a problem in the ViewModelProduct Detailspast method.\n\n");

            //do more stuff

            List<ViewModelAll> products1 = await productss;
            return products1;
        }





        // GET: CustomerController/Edit/5
        [HttpGet("edit/{id}")]
        public ActionResult Edit(int id)
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
        //// GET: api/Stores
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Store>>> GetStores()
        //{
        //    return await _context.Stores.ToListAsync();
        //}

        //// GET: api/Stores/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Store>> GetStore(int id)
        //{
        //    var store = await _context.Stores.FindAsync(id);

        //    if (store == null)
        //    {
        //        return NotFound();
        //    }

        //    return store;
        //}

        // PUT: api/Stores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutStore(int id, Store store)
        //{
        //    if (id != store.StoreId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(store).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!StoreExists(id))
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




        [HttpGet("Storelist")]
        public async Task<List<ViewModelsStore>> Details()
        {
            // call the business layer method to return list of customers
            //List<ViewModelCustomer> customers = await 
            Task<List<ViewModelsStore>> stores2 = _storerepo.StoreListAsync();
            //do stuff
            _logger.LogInformation("\n\nThere was a problem in the StoreList method.\n\n");

            //do more stuff

            List<ViewModelsStore> store1 = await stores2;
            return store1;
        }

        // POST: api/Stores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Store>> PostStore(Store store)
        //{
        //    _context.Stores.Add(store);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetStore", new { id = store.StoreId }, store);
        //}

        // DELETE: api/Stores/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteStore(int id)
        //{
        //    var store = await _context.Stores.FindAsync(id);
        //    if (store == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Stores.Remove(store);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool StoreExists(int id)
        //{
        //    return _context.Stores.Any(e => e.StoreId == id);
        //}
    }
}



//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using _08162021batchDemoStore;
//using DemoStoreBusinessLayer.Interfaces;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;

//namespace StoreDemoUi.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class CustomerController : Controller
//    {
//        private readonly ICustomerRepository _storerepo;
//        private readonly ILogger<CustomerController> _logger;

//        public CustomerController(ICustomerRepository cr, ILogger<CustomerController> logger)
//        {
//            _storerepo = cr;
//            _logger = logger;
//        }
//        // GET: CustomerController
//        public ActionResult Index()
//        {
//            //ViewModelCustomer obj = new ViewModelCustomer();
//            return View();

//        }

//        // GET: CustomerController/Details/5
//        [HttpGet("StoreList")]
//        public async Task<List<ViewModelsStore>> Details()
//        {
//            // call the business layer method to return list of customers
//            //List<ViewModelCustomer> customers = await 
//            Task<List<ViewModelsStore>> stores1 = _storerepo.StoreListAsync();
//            //do stuff
//            _logger.LogInformation("\n\nThere was a problem in the Customerlist method.\n\n");

//            //do more stuff

//            List<ViewModelsStore> stores2 = await stores1;
//            return stores2;
//        }

//        // GET: CustomerController/Create - this is the route for conventional routing 
//        // Attribute routing involves using attributes to define the path
//        [HttpPut("storecreate/{id}")]
//        public ActionResult Create(int id)
//        {
//            return View();
//        }

//        // POST: CustomerController/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: CustomerController/Edit/5
//        public ActionResult Edit(int id)
//        {
//            return View();
//        }

       
//        // POST: CustomerController/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(int id, IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }


     



//        // GET: CustomerController/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }

//        // POST: CustomerController/Delete/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Delete(int id, IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }
      
//    }
//}












//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using _08162021batchDemoStore;
//using DemoStoreBusinessLayer.Interfaces;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
//using Project1.ModelsLayer.EfModels;
//using Project1.StoreApplication.Storage.Models;



//namespace Project1.StoreApplication.Storage.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CustomersController : ControllerBase
//    {
//        private readonly ICustomerRepository _customerrepo;
//        private readonly ILogger<CustomersController> _logger;
//        private readonly Demo_08162021batchContext _context;
//        public CustomersController(ICustomerRepository cr, ILogger<CustomersController> logger)
//        {
//            _customerrepo = cr;
//            _logger = logger;
//        }
//        // GET: CustomerController
//        public ActionResult Index()
//        {
//            return View();
//        }


//        public CustomersController(Demo_08162021batchContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Customers
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
//        {
//            return await _context.Customers.ToListAsync();
//        }
//        //GET: CustomerList
//        [HttpGet("Customerlist")]
//        public async Task<List<ViewModelCustomer>> Details()
//        {
//            // call the business layer method to return list of customers
//            //List<ViewModelCustomer> customers = await 
//            Task<List<ViewModelCustomer>> customers = _customerrepo.CustomerListAsync();
//            //do stuff
//            //_logger.LogInformation("\n\nThere was a problem in the Customerlist method.\n\n");

//            //do more stuff

//            List<ViewModelCustomer> customers1 = await customers;
//            return customers1;
//        }

//        // GET: api/Customers/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Customer>> GetCustomer(int id)
//        {
//            var customer = await _context.Customers.FindAsync(id);

//            if (customer == null)
//            {
//                return NotFound();
//            }

//            return customer;
//        }

//        // PUT: api/Customers/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutCustomer(int id, Customer customer)
//        {
//            if (id != customer.CustomerId)
//            {
//                return BadRequest();
//            }

//            _context.Entry(customer).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!CustomerExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Customers
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
//        {
//            _context.Customers.Add(customer);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
//        }

//        // DELETE: api/Customers/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteCustomer(int id)
//        {
//            var customer = await _context.Customers.FindAsync(id);
//            if (customer == null)
//            {
//                return NotFound();
//            }

//            _context.Customers.Remove(customer);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool CustomerExists(int id)
//        {
//            return _context.Customers.Any(e => e.CustomerId == id);
//        }
//    }
//}

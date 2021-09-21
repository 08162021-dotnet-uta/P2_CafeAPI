using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _08162021batchDemoStore;
using DemoStoreBusinessLayer;
using DemoStoreBusinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project1.ModelsLayer.EfModels;
using Project1.StoreApplication.Storage.Models;

namespace StoreDemoUi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ViewAllController : Controller
	{
		private readonly ICustomerRepository _customerrepo;
		private readonly ILogger<CustomerController> _logger;


		public ViewAllController(ICustomerRepository cr, ILogger<CustomerController> logger)
		{
			_customerrepo = cr;
			_logger = logger;
		
		}


		// GET: CustomerController/Details/5
		[HttpGet("Customerlist")]
		public async Task<List<ViewModelCustomer>> Details()
		{
			// call the business layer method to return list of customers
			//List<ViewModelCustomer> customers = await 
			Task<List<ViewModelCustomer>> customers = _customerrepo.CustomerListAsync();
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
			//CustomerRepository hi= new CustomerRepository();
			//	//ViewModelAll mymodel = new ViewModelAll();
			//	ViewBag.ViewModelProducts = _context.Stores.FromSqlRaw<Store>($"Select Stores.StoreName FROM ItemizedOrders Join StoresProduct on ItemizedOrders.ProductId = StoresProduct.ProductId JOIN Stores on Stores.StoreId = StoresProduct.StoreId JOIN Customers on ItemizedOrders.CustomerId = Customers.CustomerId JOIN Products on Products.ProductId = ItemizedOrders.ProductId Where Stores.StoreId = StoresProduct.StoreId AND Customers.CustomerId =1 Order by ItemizedOrders.OrderDate").ToListAsync();
			//ViewBag.ViewModelItemizedOrder= _context.ItemizedOrders.FromSqlRaw<ItemizedOrder>($"Select ItemizedOrders.OrderDate, ItemizedOrders.OrderId, ItemizedOrders.StoreProductId, ItemizedOrders.CustomerId, ItemizedOrders.ProductId FROM ItemizedOrders Join StoresProduct on ItemizedOrders.ProductId = StoresProduct.ProductId JOIN Stores on Stores.StoreId = StoresProduct.StoreId JOIN Customers on ItemizedOrders.CustomerId = Customers.CustomerId JOIN Products on Products.ProductId = ItemizedOrders.ProductId Where Stores.StoreId = StoresProduct.StoreId AND Customers.CustomerId = 1 Order by ItemizedOrders.OrderDate").ToListAsync();
			//ViewBag.ViewModelStores= _context.Stores.FromSqlRaw<Store>($"Select Stores.StoreName FROM ItemizedOrders Join StoresProduct on ItemizedOrders.ProductId = StoresProduct.ProductId JOIN Stores on Stores.StoreId = StoresProduct.StoreId JOIN Customers on ItemizedOrders.CustomerId = Customers.CustomerId JOIN Products on Products.ProductId = ItemizedOrders.ProductId Where Stores.StoreId = StoresProduct.StoreId AND Customers.CustomerId = 1} Order by ItemizedOrders.OrderDate").ToListAsync();


			//	//ViewModelCustomer obj = new ViewModelCustomer();
			return View();

		}

		[HttpPost("purchasevA")]
		public async Task<ActionResult<ViewModelAll>> purchaseVAalll (ViewModelAll c)
		{
			if (!ModelState.IsValid) return BadRequest();


            //send fname and lname into a method of the business layer to check the Db fo that guy/gal;
            ViewModelAll c1 = await _customerrepo.vaPurchase(c);
            if (c1 == null)
            {
                return NotFound();
            }

            return Created($"~purchaseVmAll/{c.ProductId}", c);
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

		[HttpGet("customerpastorders/{id}")]
		public async Task<ActionResult<List<ViewModelAll>>> Details(int id)//Tuple<List<Product>, List<ItemizedOrder>, List<Store>>
		{

			//List<Product> Productss =await _context.Products.FromSqlRaw<Product>($"Select Products.ProductName, Products.ProductDescription, Products.ProductPrice, Products.ProductQuantity,Products.ProductPicture,Products.ProductId FROM ItemizedOrders Join StoresProduct on ItemizedOrders.ProductId = StoresProduct.ProductId JOIN Stores on Stores.StoreId = StoresProduct.StoreId JOIN Customers on ItemizedOrders.CustomerId = Customers.CustomerId JOIN Products on Products.ProductId = ItemizedOrders.ProductId Where Stores.StoreId = StoresProduct.StoreId AND  Customers.CustomerId ={id} Order by ItemizedOrders.OrderDate").ToListAsync();
			//List<ItemizedOrder> ItemizedOrderss = await _context.ItemizedOrders.FromSqlRaw<ItemizedOrder>($"Select ItemizedOrders.OrderDate, ItemizedOrders.ItemizedId, ItemizedOrders.OrderId, ItemizedOrders.StoreProductId, ItemizedOrders.CustomerId, ItemizedOrders.ProductId FROM ItemizedOrders Join StoresProduct on ItemizedOrders.ProductId = StoresProduct.ProductId JOIN Stores on Stores.StoreId = StoresProduct.StoreId JOIN Customers on ItemizedOrders.CustomerId = Customers.CustomerId JOIN Products on Products.ProductId = ItemizedOrders.ProductId Where Stores.StoreId = StoresProduct.StoreId AND Customers.CustomerId = {id} Order by ItemizedOrders.OrderDate").ToListAsync();
			//List<Store> storess = await _context.Stores.FromSqlRaw<Store>($"Select Stores.StoreName, Stores.StoreId FROM ItemizedOrders Join StoresProduct on ItemizedOrders.ProductId = StoresProduct.ProductId JOIN Stores on Stores.StoreId = StoresProduct.StoreId JOIN Customers on ItemizedOrders.CustomerId = Customers.CustomerId JOIN Products on Products.ProductId = ItemizedOrders.ProductId Where Stores.StoreId = StoresProduct.StoreId AND Customers.CustomerId = {id} Order by ItemizedOrders.OrderDate").ToListAsync();
			//var tupleModel = new Tuple<List<Product>, List<ItemizedOrder>, List<Store>>( Productss, ItemizedOrderss, storess);

			////do stuff
			//_logger.LogInformation("\n\nThere was a problem in the CustomerOrders Tuples Details in ViewAllController method.\n\n");

			////do more stuff
			//ViewModelAll hi = new ViewModelAll();

			//hi.getall=tupleModel;
			//return hi;

			ViewModelCustomer c = new ViewModelCustomer() { CustomerId = id };
			Task<List<ViewModelAll>> viewall = _customerrepo.getPastOrdersviewallAsync(c);
			//do stuff
			_logger.LogInformation("\n\nThere was a problem in the Details in ViewAllController method.\n\n");

			//do more stuff

			List<ViewModelAll> customers1 = await viewall;


			return customers1;




			//ViewModelAll hi = new ViewModelAll();
			//using (Demo_08162021batchContext db = new Demo_08162021batchContext())
			//{
			//	var mcsa = await
			//	(from e in db.ItemizedOrders
			//	 join p in db.StoresProducts
			//	 on e.ProductId equals p.ProductId
			//	 join s in db.Stores
			//	 on p.StoreId equals s.StoreId
			//	 join c in db.Customers
			//	 on e.CustomerId equals c.CustomerId
			//	 join pro in db.Products
			//	 on e.ProductId equals pro.ProductId
			//	 where p.StoreId == s.StoreId
			//	 & c.CustomerId == id
			//	 orderby e.OrderDate
			//	 select new
			//	 {
			//		 ProductName = pro.ProductName,
			//		 ProductDescription = pro.ProductDescription,
			//		 ProductPrice = pro.ProductPrice,
			//		 ProductQuantity = pro.ProductQuantity,
			//		 ProductId = pro.ProductId,
			//		 OrderDate = e.OrderDate,
			//		 OrderId = e.OrderId,
			//		 StoreProductId = e.StoreProductId,
			//		 Customerid = e.CustomerId,
			//		 StoreName = s.StoreName
			//	 }).ToListAsync();

			//	foreach (var p in mcsa)
			//	{
			//		hi.ProductName = p.ProductName;
			//		hi.ProductDescription = p.ProductDescription;
			//		hi.ProductPrice = p.ProductPrice;
			//		hi.ProductQuantity = p.ProductQuantity;
			//		hi.ProductId = p.ProductId;
			//		hi.OrderDate = p.OrderDate;
			//		hi.OrderId = p.OrderId;
			//		hi.StoreProductId = p.StoreProductId;
			//		hi.CustomerId = p.Customerid;
			//		hi.StoreName = p.StoreName;
			//	}
   //             }
			//return hi;
		}
	

   //                 using (Demo_08162021batchContext db = new Demo_08162021batchContext())
			//{
			//	//Disable Lazy Loading 
			//	db.Configuration.LazyLoadingEnabled = false;
			//	db.Database.Log = Console.Write;

			//	var product = (from p in db.Products
			//					.Include(p => p.ProductModel)
			//					.Include(p => p.ProductSubcategory)
			//				   where p.ProductID == 931
			//				   select p).ToList();

			//	foreach (var p in product)
			//	{
			//		Console.WriteLine("{0} {1} {2}", p.ProductID, p.Name, p.ProductModel.Name, p.ProductSubcategory.Name);
			//	}
			//}





		

		//[HttpPost("indexlogin")]
		//public ActionResult Index2(ViewModelCustomer objuserlogin)
		//{
		//	var display = Userloginvalues().Where(m => m.Email == objuserlogin.Email && m.PasswordH == objuserlogin.PasswordH).FirstOrDefault();
		//	if (display != null)
		//	{
		//		ViewBag.Status = "CORRECT UserNAme and Password";
		//	}
		//	else
		//	{
		//		ViewBag.Status = "INCORRECT UserName or Password";
		//	}
		//	return View(objuserlogin);
		//}
		//public List<ViewModelCustomer> Userloginvalues()
		//{
		//	List<ViewModelCustomer> objModel = new List<ViewModelCustomer>();
		//	objModel.Add(new ViewModelCustomer { Email = "user1", PasswordH = "password1" });
		//	objModel.Add(new ViewModelCustomer { Email = "user2", PasswordH = "password2" });
		//	objModel.Add(new ViewModelCustomer { Email = "user3", PasswordH = "password3" });
		//	objModel.Add(new ViewModelCustomer { Email = "user4", PasswordH = "password4" });
		//	objModel.Add(new ViewModelCustomer { Email = "user5", PasswordH = "password5" });
		//	return objModel;
		//}
		// POST: CustomerController/Edit/5
		//[HttpPost("editidcollection")]
		//[ValidateAntiForgeryToken]
		//public ActionResult Edit(int id, IFormCollection collection)
		//{
		//	try
		//	{
		//		return RedirectToAction(nameof(Index));
		//	}
		//	catch
		//	{
		//		return View();
		//	}
		//}


        // GET: CustomerController/Create - this is the route for conventional routing 
        // Attribute routing involves using attributes to define the path
   //     [HttpPost("register")]
   //     public async Task<ActionResult<ViewModelAll>> Create(ViewModelCustomer c)
   //     {
   //         if (!ModelState.IsValid) return BadRequest();

			////ViewModelCustomer c = new ViewModelCustomer() { Fname = fname, Lname = lname };
			////send fname and lname into a method of the business layer to check the Db fo that guy/gal;
			//ViewModelAll c1 = await _customerrepo.getPastOrdersviewallAsync(c);
   //         if (c1 == null)
   //         {
   //             return NotFound();
   //         }

   //         return Created($"~VOcustomerpastorders/{c1.StoreguidId}", c1.getall);
   //     }



  //      // GET: CustomerController/Delete/5
  //      [HttpGet("delete/{id}")]
		//public ActionResult Delete(int id)
		//{
		//	return View();
		//}

		//// POST: CustomerController/Delete/5
		//[HttpPost("deleteidcollect")]
		//[ValidateAntiForgeryToken]
		//public ActionResult Delete(int id, IFormCollection collection)
		//{
		//	try
		//	{
		//		return RedirectToAction(nameof(Index));
		//	}
		//	catch
		//	{
		//		return View();
		//	}
		//}
		/// <summary>
		/// this method takes a email and a password and retunrs a validation
		/// otherwie returns not found()
		/// </summary>
		/// <param name="id"></param>
		/// <param name="fname"></param>
		/// <param name="lname"></param>
		/// <returns></returns>

		//[HttpGet("login/{fname}/{lname}")]
		//public async Task<ActionResult<ViewModelAll>> Login(int id, string fname, string lname)
		//{

		//	if (!ModelState.IsValid) return BadRequest();


		//	ViewModelCustomer c = new ViewModelCustomer() { Fname = fname, Lname = lname };
		//	ViewModelCustomer c1 = await _customerrepo.LoginCustomerAsync(c);
		//	if (c1 == null)
  //          {
		//		return NotFound();
  //          }
			
		//	return Ok(c1);

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

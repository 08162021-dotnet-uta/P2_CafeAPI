using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLayer;
using StorageLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BusinessLayer.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CustomerController : Controller
	{
		private readonly ICustomerRepository _customerrepo;
		private readonly ILogger<CustomerController> _logger;

		public CustomerController(ICustomerRepository cr, ILogger<CustomerController> logger)
		{
			_customerrepo = cr;
			_logger = logger;
		}


		// GET: CustomerController/Details/5
		[HttpGet("Customerlist")]
		public async Task<List<ViewModelCustomer>> Details()
		{
			//if (!ModelState.IsValid) return BadRequest();
			// call the business layer method to return list of customers
			Task<List<ViewModelCustomer>> customers = _customerrepo.CustomerListAsync();
			//do stuff
			//if (customers == null)
			//{
			//	return NotFound();
			//}
			//_logger.LogInformation("\n\nThere was a problem in the Customerlist method.\n\n");
			//do more stuff
			List<ViewModelCustomer> customers1 = await customers;

			return customers1;
		}

		// GET: CustomerController/Create - this is the route for conventional routing 
		// Attribute routing involves using attributes to define the path
		[HttpPost("register")]
		public async Task<ActionResult<ViewModelCustomer>> Create(ViewModelCustomer c)
		{
			if (!ModelState.IsValid) return BadRequest();

			//send fname and lname into a method of the business layer to check the Db fo that guy/gal;
			ViewModelCustomer c1 = await _customerrepo.RegisterCustomerAsync(c);
			if (c1 == null)
			{
				return NotFound();
			}
			return Created($"~customer/{c1.Id}", c1);
		}


		/// <summary>
		/// this method takes a email and a password and retunrs a validation
		/// otherwie returns not found()
		/// </summary>
		/// <param name="id"></param>
		/// <param name="fname"></param>
		/// <param name="lname"></param>
		/// <returns></returns>

		[HttpGet("login/{fname}/{lname}")]
		public async Task<ActionResult<ViewModelCustomer>> Login(int id, string fname, string lname)
		{

			if (!ModelState.IsValid) return BadRequest();

			ViewModelCustomer c = new ViewModelCustomer() { FirstName = fname, LastName = lname };
			ViewModelCustomer c1 = await _customerrepo.LoginCustomerAsync(c);
			if (c1 == null)
			{
				return NotFound();
			}

			return Ok(c1);

		}
	}
}









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
    public class ItemizedOrdersController : Controller
    {
		private readonly ICustomerRepository _customerrepo;
		private readonly ILogger<ItemizedOrdersController> _logger;

		public ItemizedOrdersController(ICustomerRepository cr, ILogger<ItemizedOrdersController> logger)
		{
			_customerrepo = cr;
			_logger = logger;
		}


		// GET: CustomerController
		[HttpGet]
		public ActionResult Index()
		{
			//ViewModelCustomer obj = new ViewModelCustomer();
			return View();

		}


		[HttpPost("purchase")]
		public async Task<ActionResult<ViewModelItemizedOrder>> purchaseIO(ViewModelItemizedOrder c)
		{
			if (!ModelState.IsValid) return BadRequest();


			//send fname and lname into a method of the business layer to check the Db fo that guy/gal;
			ViewModelItemizedOrder c1 = await _customerrepo.ioPurchase(c);
            if (c1 == null)
            {
                return NotFound();
            }

            return Created($"~purchaseItemOrder/{c1.OrderId}", c1);
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


		[HttpPost("editidcollection")]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
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



		// GET: CustomerController/Create - this is the route for conventional routing 
		// Attribute routing involves using attributes to define the path
		[HttpPost("addtostorecartIO")]
		public async Task<ActionResult<ViewModelItemizedOrder>> Create(ViewModelItemizedOrder c)
		{
			Console.WriteLine(c);
			if (!ModelState.IsValid) return BadRequest();

			//ViewModelCustomer c = new ViewModelCustomer() { Fname = fname, Lname = lname };
			//send fname and lname into a method of the business layer to check the Db fo that guy/gal;
			ViewModelItemizedOrder c1 = await _customerrepo.addtoItemizedOrderCartAsync(c);
			if (c1 == null)
			{
				return NotFound();
			}
			Console.WriteLine(c1);

			return Created($"~ItemizedOrder/{c1.ItemizedId}", c1);
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
		
	}
}

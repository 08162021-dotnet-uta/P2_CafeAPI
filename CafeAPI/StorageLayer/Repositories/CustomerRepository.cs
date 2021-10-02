using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.EfModels;
using DatabaseLayer;


namespace StorageLayer.Repositories
{
	public class CustomerRepository : ICustomerRepository
	{
		// Step1 of DI - create  privatre instance of the dependency
		private readonly CafeContext _context;

		// step 2 of DI - call for an in stance from the DI system in your constructor.
		public CustomerRepository(CafeContext context)
		{
			_context = context;
		}

		/// <summary>
		/// This method will take a ViewModelVustomer object and return the ViewModelCustomer
		/// if found in the Db.
		/// Null if not found.
		/// </summary>
		/// <returns></returns>
		public async Task<ViewModelCustomer> LoginCustomerAsync(ViewModelCustomer vmc)
		{
			Customer c1 = ModelMapper.ViewModelCustomerToCustomer(vmc);
			Customer c2 = await _context.Customers.FromSqlRaw<Customer>("SELECT * FROM Customer WHERE FirstName = {0} and LastName = {1}", c1.FirstName, c1.LastName).FirstOrDefaultAsync();// default is NULL
			if (c2 == null) return null;
			ViewModelCustomer c3 = ModelMapper.CustomerToViewModelCustomer(c2);
			return c3;
		}

		public async Task<ViewModelCustomer> RegisterCustomerAsync(ViewModelCustomer vmc)
		{
			Customer c1 = ModelMapper.ViewModelCustomerToCustomer(vmc);
			int c2 = await _context.Database.ExecuteSqlRawAsync("INSERT INTO Customer (FirstName, LastName) VALUES ({0},{1})", c1.FirstName, c1.LastName);// default is NULL
			if (c2 != 1) return null;
			return await LoginCustomerAsync(vmc);
		}
		//	public async Task<List<Customer>> CustomerListAsync()
		public async Task<List<ViewModelCustomer>> CustomerListAsync()
		{
			List<Customer> customers = await _context.Customers.FromSqlRaw<Customer>("Select * FROM Customer").ToListAsync();
			List<ViewModelCustomer> vmc = new List<ViewModelCustomer>();
			foreach (Customer c in customers)
			{
				vmc.Add(ModelMapper.CustomerToViewModelCustomer(c));
			}
			return vmc;
		}
	}// EoC
}// EoN

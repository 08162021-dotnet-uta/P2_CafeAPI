using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer;
using ModelsLayer.EfModels;
using StorageLayer.Interfaces;

namespace StorageLayer
{
	public class ModelMapper : IModelMapper
	{
		/// <summary>
		/// THis method takes a Customer and returns the mapping to a ViewModelCustomer
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		public static ViewModelCustomer CustomerToViewModelCustomer(Customer c)
		{
			ViewModelCustomer c1 = new ViewModelCustomer();
			c1.Id = c.Id;
			c1.FirstName = c.FirstName;
			c1.LastName = c.LastName;
			return c1;
		}

		/// <summary>
		/// This method takes a ViewModelCustomer and returns the mapping to a Customer
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		public static Customer ViewModelCustomerToCustomer(ViewModelCustomer c)
		{
			Customer c1 = new Customer();
			c1.Id = c.Id;
			c1.FirstName = c.FirstName;
			c1.LastName = c.LastName;
			return c1;
		}

		
	}
}

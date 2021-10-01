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

		/// <summary>
		/// This method takes a ViewModelProduct and returns the mapping to a Product
		/// </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		public static Product ViewModelProductToProduct(ViewModelProduct p)
		{
			Product p1 = new Product();
			p1.Id = p.Id;
			p1.Name = p.Name;
			p1.Description = p.Description;
			p1.Price = p.Price;
			p1.Inventory = p.Inventory;
			return p1;
		}

		/// <summary>
		/// This method takes a Product and returns the mapping to a ViewModelProduct
		/// </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		public static ViewModelProduct ProductToViewModelProduct(Product p)
		{
			ViewModelProduct p1 = new ViewModelProduct();
			p1.Id = p.Id;
			p1.Name = p.Name;
			p1.Description = p.Description;
			p1.Price = p.Price;
			p1.Inventory = p.Inventory;

			return p1;
		}


	}
}

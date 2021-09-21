using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08162021batchDemoStore;
using DemoStoreBusinessLayer.Interfaces;
using Project1.ModelsLayer.EfModels;

namespace DemoStoreBusinessLayer
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
			c1.CustomerId = c.CustomerId;
			c1.Fname = c.FirstName;
			c1.Lname = c.LastName;
			c1.Email = c.Email;
			c1.PasswordH = c.PasswordH;
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
			c1.CustomerId = c.CustomerId;
			c1.FirstName = c.Fname;
			c1.LastName = c.Lname;
			c1.Email = c.Email;
			c1.PasswordH = c.PasswordH;
			return c1;
		}

		/// <summary>
		/// This method takes a ViewModelCustomer and returns the mapping to a Customer
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		public static ItemizedOrder ViewItemizedOrdertoItemizedOrder(ViewModelItemizedOrder c)
		{
			ItemizedOrder c1 = new ItemizedOrder();
			c1.OrderDate = c.OrderDate;
			c1.OrderId = c1.OrderId;
			c1.ProductId = c.ProductId;
			c1.StoreProductId = c.StoreProductId;
			c1.ItemizedId = c.ItemizedId;
			c1.CustomerId = c.CustomerId;

			return c1;
		}

		/// <summary>
		/// This method takes a ViewModelCustomer and returns the mapping to a Customer
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		public static ViewModelItemizedOrder itemizedOrdertoViewmodelItemizedOrder(ItemizedOrder c)
		{
			ViewModelItemizedOrder c1 = new ViewModelItemizedOrder();
			c1.OrderDate = c.OrderDate;
			c1.OrderId = c1.OrderId;
			c1.ProductId = c.ProductId;
			c1.StoreProductId = c.StoreProductId;
			c1.ItemizedId = c.ItemizedId;
			c1.CustomerId = c.CustomerId;
			return c1;
		}

		/// <summary>
		/// This method takes a ViewModelProduct and returns the mapping to a Product
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		public static Product ViewModelProductToProduct(ViewModelProduct c)
		{
			Product c1 = new Product();
			c1.ProductId = c.ProductId;
			c1.ProductName = c.ProductName;
			c1.ProductPrice = c.ProductPrice;
			return c1;
		}
		public static StoresProduct ViewModelStoreProductToProduct(ViewModelStoreProduct c)
		{
			StoresProduct c1 = new StoresProduct();
			c1.ProductId = c.ProductId;
			//c1.StoreguidId = c.StoreguidId;
			//c1.StoreProductId = c.StoreProductId;
			c1.StoreId = c.StoreId;
			return c1;
		}
		public static ViewModelStoreProduct ProducttoViewModelStoreProduct(StoresProduct c)
		{
			ViewModelStoreProduct c1 = new ViewModelStoreProduct();
			c1.ProductId = c.ProductId;
			//c1.StoreguidId = c.StoreguidId;
			//c1.StoreProductId = c.StoreProductId;
			c1.StoreId = c.StoreId;
			return c1;
		}
	
		/// <summary>
		/// This method takes a Product and returns the mapping to a ViewModelProduct
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		public static ViewModelProduct ProductToViewModelProduct(Product c)
		{
			ViewModelProduct c1 = new ViewModelProduct();
			c1.ProductId = c.ProductId;
			c1.ProductName = c.ProductName;
			c1.ProductDescription = c.ProductDescription;
			c1.ProductPrice = c.ProductPrice;
			c1.ProductQuantity = c.ProductQuantity;
			c1.ProductPicture = c.ProductPicture;
			return c1;
		}



		public static ViewModelsStore StoreToViewModelStore(Store c)
		{
			ViewModelsStore c1 = new ViewModelsStore();
			c1.StoreId = c.StoreId;
			c1.StoreName = c.StoreName;
			return c1;
		}

		/// <summary>
		/// This method takes a ViewModelCustomer and returns the mapping to a Customer
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		public static Store ViewModelsStoreToStore(ViewModelsStore c)
		{
			Store c1 = new Store();
			c1.StoreId = c.StoreId;
			c1.StoreName = c.StoreName;
			return c1;
		}
	}
}

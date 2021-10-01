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
		/// This method takes an Order and returns the mapping to a ViewModelOrder
		/// </summary>
		/// <param name="o"></param>
		/// <returns></returns>
		public static ViewModelOrder OrderToViewModelOrder(Order o)
		{
			ViewModelOrder o1 = new ViewModelOrder();
			o1.Id = o.Id;
			o1.CustomerId = o.CustomerId;
			o1.NumberOfItems = o.NumberOfItems;
			o1.TotalPrice = o.TotalPrice;
			return o1;
		}

		/// <summary>
		/// This method takes a ViewModelOrder and returns the mapping to an Order
		/// </summary>
		/// <param name="o"></param>
		/// <returns></returns>
		public static Order ViewModelOrderToOrder(ViewModelOrder o) 
		{
			Order o1 = new Order();
			o1.Id = o.Id;
			o1.CustomerId = o.CustomerId;
			o1.NumberOfItems = o.NumberOfItems;
			o1.TotalPrice = o.TotalPrice;
			return o1;
		}

		/// <summary>
		/// This method takes an OrderItem and returns the mapping to a ViewModelOrderItem
		/// </summary>
		/// <param name="oi"></param>
		/// <returns></returns>
		public static ViewModelOrderItem OrderItemToViewModelOrderItem(OrderItem oi) 
		{
			ViewModelOrderItem oi1 = new ViewModelOrderItem();
			oi1.OrderId = oi1.OrderId;
			oi1.ProductId = oi1.ProductId;
			return oi1;
		}

		/// <summary>
		/// This method takes a ViewModelOrderItem and returns the mapping to an OrderItem
		/// </summary>
		/// <param name="oi"></param>
		/// <returns></returns>
		public static OrderItem ViewModelOrderItemToOrderItem(ViewModelOrderItem oi)
        {
			OrderItem oi1 = new OrderItem();
			oi1.OrderId = oi1.OrderId;
			oi1.ProductId = oi1.ProductId;
			return oi1;
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
	}
}

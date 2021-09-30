using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer;
using ModelsLayer.EfModels;

namespace StorageLayer.Interfaces
{
	public interface IModelMapper
	{
		ViewModelCustomer CustomerToViewModelCustomer(Customer c) { throw new NotImplementedException(); }
		Customer ViewModelCustomerToCustomer(ViewModelCustomer c) { throw new NotImplementedException(); }
		ViewModelOrder OrderToViewModelOrder(Order o) { throw new NotImplementedException(); }
		Order ViewModelOrderToOrder(ViewModelOrder o) { throw new NotImplementedException(); }
		ViewModelOrderItem OrderItemToViewModelOrderItem(OrderItem oi) { throw new NotImplementedException(); }
		OrderItem ViewModelOrderItemToOrderItem(ViewModelOrderItem oi) { throw new NotImplementedException(); }
		ViewModelProduct ProductToViewModelProduct(Product p) { throw new NotImplementedException(); }
		Product ViewModelProductToProduct(ViewModelProduct p) { throw new NotImplementedException(); }
	}
}

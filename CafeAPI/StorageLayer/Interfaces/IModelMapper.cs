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
	}
}

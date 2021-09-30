using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer;
//using ModelsLayer.EfModels;
namespace StorageLayer.Interfaces
{
	public interface ICustomerRepository
	{
		Task<ViewModelCustomer> LoginCustomerAsync(ViewModelCustomer vmc);
		Task<ViewModelCustomer> RegisterCustomerAsync(ViewModelCustomer vmc);
		 Task<List<ViewModelCustomer>> CustomerListAsync();
		//Task<List<Customer>> CustomerListAsync();

	}
}

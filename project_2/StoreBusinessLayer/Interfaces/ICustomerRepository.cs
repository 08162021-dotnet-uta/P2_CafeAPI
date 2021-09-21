using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08162021batchDemoStore;

namespace DemoStoreBusinessLayer.Interfaces
{
	public interface ICustomerRepository
	{
		Task<ViewModelCustomer> LoginCustomerAsync(ViewModelCustomer vmc);
		Task<ViewModelCustomer> RegisterCustomerAsync(ViewModelCustomer vmc);
		Task<List<ViewModelProduct>> StoreProductListAsync(ViewModelsStore vmc2);
		Task<List<ViewModelProduct>> ProductsAsync(int prodId = -1);
		Task<List<ViewModelProduct>> getPastOrdersAsync(ViewModelCustomer vmcC, ViewModelsStore vmcS);
		Task<List<ViewModelCustomer>> CustomerListAsync();
		Task<List<ViewModelsStore>> StoreListAsync();
		Task<ViewModelStoreProduct> addtoStoreCartAsync(ViewModelStoreProduct vmc);
		Task<ViewModelItemizedOrder> addtoItemizedOrderCartAsync(ViewModelItemizedOrder vmc);
		Task<List<ViewModelAll>> getPastOrdersStoreAsync(ViewModelsStore vmcS);
		Task<List<ViewModelAll>> getPastOrdersviewallAsync(ViewModelCustomer vmcC);
		Task<ViewModelItemizedOrder> ioPurchase(ViewModelItemizedOrder vmio);
		Task<ViewModelAll> vaPurchase(ViewModelAll vmva);
	}
}

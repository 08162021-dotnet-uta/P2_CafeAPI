using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08162021batchDemoStore;
using DemoStoreBusinessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Project1.ModelsLayer.EfModels;
using Project1.StoreApplication.Storage.Models;


namespace DemoStoreBusinessLayer
{
	public class CustomerRepository : ICustomerRepository
	{
		// Step1 of DI - create  privatre instance of the dependency
		private readonly Demo_08162021batchContext _context;

		// step 2 of DI - call for an in stance from the DI system in your constructor.
		public CustomerRepository(Demo_08162021batchContext context)
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

			Customer c2 = await _context.Customers.FromSqlRaw<Customer>("SELECT * FROM Customers WHERE FirstName = {0} and LastName = {1}", c1.FirstName, c1.LastName).FirstOrDefaultAsync();// default is NULL

			if (c2 == null) return null;

			ViewModelCustomer c3 = ModelMapper.CustomerToViewModelCustomer(c2);
			return c3;
		}

		public async Task<ViewModelCustomer> RegisterCustomerAsync(ViewModelCustomer vmc)
		{
			Customer c1 = ModelMapper.ViewModelCustomerToCustomer(vmc);
			

			int c2 = await _context.Database.ExecuteSqlRawAsync("INSERT INTO Customers (FirstName, LastName, Email) VALUES ({0},{1},{2})", c1.FirstName, c1.LastName, c1.Email);// default is NULL

			if (c2 != 1) return null;

			//Customer c3 = _context.Customers.FromSqlRaw<Customer>("SELECT * FROM Customers WHERE FirstName = {0} and LastName = {1}", c1.FirstName, c1.LastName).FirstOrDefault();// default is NULL

			//if (c2 == null) return null;

			//ViewModelCustomer c4 = ModelMapper.CustomerToViewModelCustomer(c3);
			//return c4;

			return await LoginCustomerAsync(vmc);
		}

		public async Task<ViewModelItemizedOrder> ioPurchase(ViewModelItemizedOrder vmio)
		{
			ItemizedOrder c1 = ModelMapper.ViewItemizedOrdertoItemizedOrder(vmio);


			int c2 = await _context.Database.ExecuteSqlRawAsync("INSERT INTO ItemizedOrders(OrderId,CustomerId,StoreProductId,ProductId,OrderDate) VALUES ({0},{1},{2},{3},{4})", c1.OrderId, c1.CustomerId, c1.StoreProductId,c1.ProductId,c1.OrderDate);// default is NULL

			if (c2 != 1) return null;


			ItemizedOrder c3 = await _context.ItemizedOrders.FromSqlRaw<ItemizedOrder>("SELECT * FROM  ItemizedOrders WHERE OrderId = {0} ", c1.OrderId).FirstOrDefaultAsync();// default is NULL

			if (c3 == null) return null;

			ViewModelItemizedOrder c4 = ModelMapper.itemizedOrdertoViewmodelItemizedOrder(c3);
			return c4;
		}

		//  DateTime.Now *** COULD NOT GET DATETIME TO WORK below
		public async Task<ViewModelAll> vaPurchase(ViewModelAll vmva)// async Task<ViewModelAll> 
		{
			Guid guid = Guid.NewGuid();
			int sp = await _context.Database.ExecuteSqlRawAsync("INSERT INTO StoresProduct(StoreguidId,StoreId,ProductId) VALUES ({0},{1},{2})", guid, vmva.StoreId, vmva.ProductId);// default is NULL
			if (sp != 1) return null;
			StoresProduct spid = await _context.StoresProducts.FromSqlRaw<StoresProduct>($"SELECT * FROM StoresProduct Where StoreguidId ='{guid}'").FirstOrDefaultAsync();
			if (spid == null) return null;

            //DateTime dt = DateTime.Now;
            Console.WriteLine("Task<viewModeAll> vaPurchase in CustomerRepository has hard coded datetime");
            //string hi = dt.ToString("yyyy-MM-ddTHH:mm:sssZ");
            int io1 = await _context.Database.ExecuteSqlRawAsync("INSERT INTO ItemizedOrders(OrderId,CustomerId,StoreProductId,ProductId,OrderDate) VALUES ({0},{1},{2},{3},{4})", guid, vmva.CustomerId, spid.StoreProductId, vmva.ProductId, vmva.OrderDate);//  DateTime.Now *** COULD NOT GET DATETIME TO WORK
			if (io1 != 1) return null;
			ItemizedOrder io2 = await _context.ItemizedOrders.FromSqlRaw<ItemizedOrder>($"SELECT * FROM  ItemizedOrders WHERE OrderId = '{guid}' ").FirstOrDefaultAsync();// default is NULL
			if (io2 == null) return null;

			//update quantity
			int sp3 = await _context.Database.ExecuteSqlRawAsync("Update Products SET ProductQuantity = ProductQuantity -1 WHERE ProductId = {0}",vmva.ProductId);// default is NULL
			if (sp3 != 1) return null;

		return vmva;
		}
		public async Task<ViewModelStoreProduct> addtoStoreCartAsync(ViewModelStoreProduct vmc)
		{
			StoresProduct c1 = ModelMapper.ViewModelStoreProductToProduct(vmc);


			int c2 = await _context.Database.ExecuteSqlRawAsync("INSERT INTO StoresProduct(StoreguidId,StoreId,ProductId) VALUES ({0},{1},{2})", Guid.NewGuid(), c1.StoreId, c1.ProductId);// default is NULL

			if (c2 != 1) return null;


			StoresProduct c3 = await _context.StoresProducts.FromSqlRaw<StoresProduct>("SELECT * FROM  StoresProduct WHERE StoreId = {0} and ProductId = {1}", c1.StoreId, c1.StoreProductId).FirstOrDefaultAsync();// default is NULL

			if (c3 == null) return null;

			ViewModelStoreProduct c4 = ModelMapper.ProducttoViewModelStoreProduct(c3);
			return c4;
		}

		public async Task<ViewModelItemizedOrder> addtoItemizedOrderCartAsync(ViewModelItemizedOrder vmc)
		{
			ItemizedOrder c1 = ModelMapper.ViewItemizedOrdertoItemizedOrder(vmc);
			StoresProduct sp = await _context.StoresProducts.FromSqlRaw<StoresProduct>("SELECT MAX(StoreProductId) FROM  StoresProduct ").FirstOrDefaultAsync();// default is NULL

			Guid obj = Guid.NewGuid();
			Console.WriteLine(sp.StoreProductId);
			int c2 = await _context.Database.ExecuteSqlRawAsync("INSERT INTO ItemizedOrders(OrderId, CustomerId, StoreProductId, ProductId, OrderDate) VALUES({ 0}, { 1}, { 2}, { 3}, { 4},{ 5})", obj, c1.CustomerId,sp.StoreProductId,c1.ProductId, c1.OrderDate);// default is NULL


			if (c2 != 1) return null;


			ItemizedOrder c3 = await _context.ItemizedOrders.FromSqlRaw<ItemizedOrder>("SELECT * FROM  ItemizedOrders WHERE CustomerId = {0} and StoreProductId = {1} and OrderId= {2}", c1.CustomerId, sp.StoreProductId, obj).FirstOrDefaultAsync();// default is NULL

			if (c3 == null) return null;

			ViewModelItemizedOrder c4 = ModelMapper.itemizedOrdertoViewmodelItemizedOrder(c3);
			return c4;
		}

		/// <summary>
		/// This method getss a list of all the products or a single product given an arg.
		/// </summary>
		/// <returns></returns>
		public async Task<List<ViewModelProduct>> ProductsAsync(int prodId = -1)
		{
			List<ViewModelProduct> viewmodelproducts = new List<ViewModelProduct>();
			// get all the products
			if (prodId == -1)
			{
				List<Product> products = await _context.Products.FromSqlRaw<Product>("Select * FROM Products").ToListAsync();
				// convert to ViewMOdelProduct
				foreach (Product p in products)
				{
					viewmodelproducts.Add(ModelMapper.ProductToViewModelProduct(p));
				}
				return viewmodelproducts;
			}
			else
			{
				List<Product> products = await _context.Products.FromSqlRaw<Product>($"Select TOP 1 FROM Products WHERE ProductId = {prodId}").ToListAsync();
				// convert to ViewMOdelProduct
				foreach (Product p in products)
				{
					viewmodelproducts.Add(ModelMapper.ProductToViewModelProduct(p));
				}
				return viewmodelproducts;
			}
		}

		public async Task<List<ViewModelCustomer>> CustomerListAsync()
		{
			List<Customer> customers = await _context.Customers.FromSqlRaw<Customer>("Select * FROM Customers").ToListAsync();
			List<ViewModelCustomer> vmc = new List<ViewModelCustomer>();
			foreach (Customer c in customers)
			{
				vmc.Add(ModelMapper.CustomerToViewModelCustomer(c));
			}
			return vmc;
		}
		public async Task<List<ViewModelsStore>> StoreListAsync()
		{
			List<Store> storess = await _context.Stores.FromSqlRaw<Store>("Select * FROM Stores").ToListAsync();
			List<ViewModelsStore> vmc = new List<ViewModelsStore>();
			foreach (Store c in storess)
			{
				vmc.Add(ModelMapper.StoreToViewModelStore(c));
			}

			return vmc;
		}

        public async Task<List<ViewModelProduct>> StoreProductListAsync(ViewModelsStore vmc2)
        {
			Store c1 = ModelMapper.ViewModelsStoreToStore(vmc2);

			List<Product> productss = await _context.Products.FromSqlRaw<Product>($"Select Products.ProductId, ProductName,ProductDescription,ProductPrice,ProductQuantity,ProductPicture from Products Join StoresProduct on Products.ProductId = StoresProduct.ProductId WHERE StoreId={c1.StoreId} AND StoresProduct.StoreguidId = '2F473542-41C7-4F87-A5B3-717AFE821305'").ToListAsync();///* AND StoreguidId = {Guid.Parse("2F472542-41C7-4F87-A5B3-717AFE821305")

			List <ViewModelProduct> vmc = new List<ViewModelProduct>();
            foreach (Product c in productss)
            {

				vmc.Add(ModelMapper.ProductToViewModelProduct(c));
            }

            return vmc;
        }
		public async Task<List<ViewModelProduct>> getPastOrdersAsync(ViewModelCustomer vmcC,ViewModelsStore vmcS)
		{
			Store c1 = ModelMapper.ViewModelsStoreToStore(vmcS);
			Customer c2 = ModelMapper.ViewModelCustomerToCustomer(vmcC);

			List<Product> productss = await _context.Products.FromSqlRaw<Product>($"Select Products.ProductName, Products.ProductDescription, Products.ProductPrice, Products.ProductQuantity,Products.ProductPicture,Products.ProductId FROM ItemizedOrders Join StoresProduct on ItemizedOrders.ProductId = StoresProduct.ProductId JOIN Stores on Stores.StoreId = StoresProduct.StoreId JOIN Customers on ItemizedOrders.CustomerId=Customers.CustomerId JOIN Products on Products.ProductId=ItemizedOrders.ProductId Where Stores.StoreId= StoresProduct.StoreId AND Stores.StoreId={vmcS.StoreId} AND Customers.CustomerId={vmcC.CustomerId}").ToListAsync();
			List<ViewModelProduct> vmc = new List<ViewModelProduct>();
			foreach (Product c in productss)
			{

				vmc.Add(ModelMapper.ProductToViewModelProduct(c));
			}

			return vmc;
		}

		public async Task<List<ViewModelAll>> getPastOrdersviewallAsync(ViewModelCustomer vmcC)
		{
			ViewModelAll hi = new ViewModelAll();
			List<ViewModelAll> hiList = new List<ViewModelAll>();
			using (Demo_08162021batchContext db = new Demo_08162021batchContext())
			{
				var mcsa = 
				(from e in db.ItemizedOrders
				 join p in db.StoresProducts
				 on e.ProductId equals p.ProductId
				 join s in db.Stores
				 on p.StoreId equals s.StoreId
				 join c in db.Customers
				 on e.CustomerId equals c.CustomerId
				 join pro in db.Products
				 on e.ProductId equals pro.ProductId
				 where c.CustomerId == vmcC.CustomerId
				 orderby e.OrderDate ascending
				 select new 
				 {
					 ProductName = pro.ProductName,
					 ProductDescription = pro.ProductDescription,
					 ProductPrice = pro.ProductPrice,
					 ProductQuantity = pro.ProductQuantity,
					 ProductId = pro.ProductId,
					 OrderDate = e.OrderDate,
					 OrderId = e.OrderId,
					 StoreProductId = e.StoreProductId,
					 Customerid = e.CustomerId,
					 StoreName = s.StoreName
					 
				 }).Distinct().ToListAsync();

				foreach (var p in await mcsa)
				{
					//Console.WriteLine(p.ProductPrice);
					hi = new ViewModelAll();
					hi.ProductName = p.ProductName;
					hi.ProductDescription = p.ProductDescription;
					hi.ProductPrice = p.ProductPrice;
					hi.ProductQuantity = p.ProductQuantity;
					hi.ProductId = p.ProductId;
					hi.OrderDate = p.OrderDate;
					hi.OrderId = p.OrderId;
					hi.StoreProductId = p.StoreProductId;
					hi.CustomerId = p.Customerid;
					hi.StoreName = p.StoreName;
					hiList.Add(hi);
				}

			}
			return hiList;
		}
            

                public List<Product> GetProduct(List<ViewModelProduct> vmcC2)
		{
			List<Product> products = new List<Product>();
			foreach (ViewModelProduct c in vmcC2)
			{

				products.Add(ModelMapper.ViewModelProductToProduct(c));
			}
			return products;
		}

		public List<Store> GetStore(List<ViewModelsStore> vmcS)
		{
			List<Store> Stores = new List<Store>();
			foreach (ViewModelsStore c in vmcS)
			{

				Stores.Add(ModelMapper.ViewModelsStoreToStore(c));
			}
			return Stores;
		}
		public List<ItemizedOrder> GetItemizedOrders(List<ViewModelItemizedOrder> vmcIO)
		{
			List<ItemizedOrder> ItemizedOrders = new List<ItemizedOrder>();
			foreach (ViewModelItemizedOrder c in vmcIO)
			{

				ItemizedOrders.Add(ModelMapper.ViewItemizedOrdertoItemizedOrder(c));
			}
			return ItemizedOrders;
		}


		public async Task<List<ViewModelAll>> getPastOrdersStoreAsync( ViewModelsStore vmcS)
		{
			Store c1 = ModelMapper.ViewModelsStoreToStore(vmcS);
			ViewModelAll hi = new ViewModelAll();
			List<ViewModelAll> hiList = new List<ViewModelAll>();
			using (Demo_08162021batchContext db = new Demo_08162021batchContext())
			{
				var mcsa =
				(from e in db.ItemizedOrders
				 join p in db.StoresProducts
				 on e.ProductId equals p.ProductId
				 join s in db.Stores
				 on p.StoreId equals s.StoreId
				 join c in db.Customers
				 on e.CustomerId equals c.CustomerId
				 join pro in db.Products
				 on e.ProductId equals pro.ProductId
				 where s.StoreId == vmcS.StoreId
				 orderby e.OrderDate ascending
				 select new
				 {
					 ProductName = pro.ProductName,
					 ProductDescription = pro.ProductDescription,
					 ProductPrice = pro.ProductPrice,
					 ProductQuantity = pro.ProductQuantity,
					 ProductId = pro.ProductId,
					 OrderDate = e.OrderDate,
					 OrderId = e.OrderId,
					 StoreProductId = e.StoreProductId,
					 Customerid = e.CustomerId,
					 StoreName = s.StoreName

				 }).Distinct().ToListAsync();

				foreach (var p in await mcsa)
				{
					//Console.WriteLine(p.ProductPrice);
					hi = new ViewModelAll();
					hi.ProductName = p.ProductName;
					hi.ProductDescription = p.ProductDescription;
					hi.ProductPrice = p.ProductPrice;
					hi.ProductQuantity = p.ProductQuantity;
					hi.ProductId = p.ProductId;
					hi.OrderDate = p.OrderDate;
					hi.OrderId = p.OrderId;
					hi.StoreProductId = p.StoreProductId;
					hi.CustomerId = p.Customerid;
					hi.StoreName = p.StoreName;
					hiList.Add(hi);
				}
			}
			return hiList;


			//Store c1 = ModelMapper.ViewModelsStoreToStore(vmcS);
			//Customer c2 = ModelMapper.ViewModelCustomerToCustomer(vmcC);
			//Store c1 = ModelMapper.ViewModelsStoreToStore(vmcS);
	
			//List<Product> productss = await _context.Products.FromSqlRaw<Product>($"Select Products.ProductName, Products.ProductDescription, Products.ProductPrice, Products.ProductQuantity,Products.ProductPicture,Products.ProductId FROM ItemizedOrders Join StoresProduct on ItemizedOrders.ProductId = StoresProduct.ProductId JOIN Stores on Stores.StoreId = StoresProduct.StoreId JOIN Customers on ItemizedOrders.CustomerId=Customers.CustomerId JOIN Products on Products.ProductId=ItemizedOrders.ProductId Where Stores.StoreId= StoresProduct.StoreId AND Stores.StoreId=${vmcS.StoreId}").ToListAsync();
			//List<ViewModelProduct> vmc = new List<ViewModelProduct>();
			//foreach (Product c in productss)
			//{

			//	vmc.Add(ModelMapper.ProductToViewModelProduct(c));
			//}

			//return vmc;
		}




	}// EoC
}// EoN

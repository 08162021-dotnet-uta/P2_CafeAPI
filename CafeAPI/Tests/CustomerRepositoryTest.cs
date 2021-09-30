using Microsoft.EntityFrameworkCore;
using StorageLayer.Interfaces;
using StorageLayer;
using System;
using System.Collections.Generic;
using ModelsLayer.EfModels;
using ModelsLayer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DatabaseLayer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;



namespace Tests
{
    
    public class CustomerRepositoryTests
    {
       
        testprojectContext _context = new testprojectContext();

        [Fact]
        public async Task FindCustomerTest()
        {

            int lengthOriginal, lengthNew;
            CustomerRepository _customerrepo = new CustomerRepository(_context);
            Task<List<ViewModelCustomer>> customers = _customerrepo.CustomerListAsync();
            customers.Wait();
            List<ViewModelCustomer> customers1 = await customers;
                        lengthOriginal = customers1.Count+1;
            Customer c1 = new Customer() { FirstName = "Ben", LastName = "Test" };
            _context.Customers.Add(c1);
            _context.SaveChanges();

            CustomerRepository _customerrepo2 = new CustomerRepository(_context);
            Task<List<ViewModelCustomer>> customers2 = _customerrepo.CustomerListAsync();
            customers2.Wait();
            List<ViewModelCustomer> customers21 = await customers2;
            lengthNew = customers21.Count;
            Assert.Equal(lengthOriginal,lengthNew);
            Assert.True(customers21[lengthNew-1].FirstName== "Ben");

        }

        [Fact]
        public void loginCustomerTest()
        {
            CustomerRepository _customerrepo = new CustomerRepository(_context);
            Customer c1 = new Customer() { FirstName = "Benlogin", LastName = "Test" };
            

            ViewModelCustomer c11 = ModelMapper.CustomerToViewModelCustomer(c1);
            Task<ViewModelCustomer> customers = _customerrepo.LoginCustomerAsync(c11);
            customers.Wait();
            _context.SaveChanges();
            //ViewModelCustomer c2 = new ViewModelCustomer { FirstName = "newBen", LastName = "Fr7anklin" };

            //Task<ViewModelCustomer> customers2 = _customerrepo.LoginCustomerAsync(c2);
            //customers.Wait();
            Assert.NotNull(customers);
            //Assert.Null(customers2);
         }

        [Fact]
        public async Task registerCustomerTest()
        {
            //using (Kyles_Pizza_ShopContext _context = new Kyles_Pizza_ShopContext(options))
            //{

            //RegisterCustomerAsync
            int lengthOriginal, lengthNew;
            CustomerRepository _customerrepo = new CustomerRepository(_context);
            Task<List<ViewModelCustomer>> customers = _customerrepo.CustomerListAsync();
            customers.Wait();
            List<ViewModelCustomer> customers1 = await customers;
            lengthOriginal = customers1.Count ;

            Customer c1 = new Customer() { FirstName = "Benregister", LastName = "Test" };
            ViewModelCustomer c11 = ModelMapper.CustomerToViewModelCustomer(c1);
            Task<ViewModelCustomer> customers2 = _customerrepo.RegisterCustomerAsync(c11);
            customers2.Wait();
            _context.SaveChanges();


            Task<List<ViewModelCustomer>> customers3 = _customerrepo.CustomerListAsync();
            customers.Wait();
            List<ViewModelCustomer> customers33 = await customers3;
            lengthNew = customers33.Count;


            _context.SaveChanges();
            customers.Wait();
            Assert.Equal(lengthOriginal+1, lengthNew);

        }
 
          
        }
    }

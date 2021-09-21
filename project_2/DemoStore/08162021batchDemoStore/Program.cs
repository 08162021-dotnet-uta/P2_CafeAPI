using Microsoft.EntityFrameworkCore;
using Project1.ModelsLayer.EfModels;
using Project1.StoreApplication.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _08162021batchDemoStore
{
    class Program
    {
        static void Main(string[] args)
        {
            using(Demo_08162021batchContext context= new Demo_08162021batchContext())
            {
                //var customers = context.Customers.ToList();"Select * FROM Stores

                List<Store> stores = context.Stores.FromSqlRaw<Store>("Select * FROM Stores").ToList();
                foreach (var x in stores)
                {
                    Console.WriteLine($"The customer is {x.StoreId} {x.StoreName}");
                }

                //List<Customer> customers = context.Customers.FromSqlRaw<Customer>("SELECT * FROM Customers").ToList();
                //foreach (var x in customers)
                //{
                //    Console.WriteLine($"The customer is {x.FirstName} {x.LastName}");
                //}
            }
        }
    }
}

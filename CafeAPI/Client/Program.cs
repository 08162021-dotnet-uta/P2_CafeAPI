using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using DatabaseLayer;
using ModelsLayer.EfModels;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (testprojectContext context = new testprojectContext())
            {
                //var customers = context.Customers.ToList();"Select * FROM Stores

                List<Customer> customers = context.Customers.FromSqlRaw<Customer>("Select * FROM Customer").ToList();
                foreach (var x in customers)
                {
                    Console.WriteLine($"The customer is {x.FirstName} {x.LastName}");
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

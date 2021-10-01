using DatabaseLayer;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.EfModels;
using StorageLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageLayer
{
    public class OrderRepository : IOrderRepository
    {
        // Step1 of DI - create  privatre instance of the dependency
        private readonly testprojectContext _context;

        // step 2 of DI - call for an in stance from the DI system in your constructor.
        public OrderRepository(testprojectContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This method will retrieve a list of orders based on CustomerId
        /// </summary>
        /// <param name="vmo"></param>
        /// <returns></returns>
        //public async Task<ViewModelOrder> OrderListAsync(int customerId)
        //{
        //    Order o1 = ModelMapper.ViewModelOrderToOrder(vmo);
        //    Order o2 = await _context.Orders.FromSqlRaw<Order>("SELECT * FROM [Order] WHERE CustomerId = {0}", o1.CustomerId).FirstOrDefaultAsync();// default is NULL

        //    if (o2 == null) return null;

        //    ViewModelOrder o3 = ModelMapper.OrderToViewModelOrder(o2);
        //    return o3;
        //}

        /// <summary>
        /// This method will add a new order to the Order table in the Db
        /// </summary>
        /// <param name="vmo"></param>
        /// <returns></returns>
        public async Task<ViewModelOrder> PlaceOrderAsync(ViewModelOrder vmo)
        {
            Order o1 = ModelMapper.ViewModelOrderToOrder(vmo);
            int o2 = await _context.Database.ExecuteSqlRawAsync("INSERT INTO [Order (CustomerId, NumberOfItems, TotalPrice) VALUES ({0},{1},{2})", o1.CustomerId, o1.NumberOfItems, o1.TotalPrice);// default is NULL
            if (o2 != 1) return null;
            return await OrderListAsync(vmo.CustomerId);
        }
    }
}

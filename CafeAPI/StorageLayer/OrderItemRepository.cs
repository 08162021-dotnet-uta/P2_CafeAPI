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
    public class OrderItemRepository : IOrderItemRepository
    {
        // Step1 of DI - create  privatre instance of the dependency
        private readonly testprojectContext _context;

        // step 2 of DI - call for an in stance from the DI system in your constructor.
        public OrderItemRepository(testprojectContext context)
        {
            _context = context;
        }
        public async Task<ViewModelOrderItem> AddOrderItemAsync(ViewModelOrderItem vmoi)
        {
            OrderItem oi1 = ModelMapper.ViewModelOrderItemToOrderItem(vmoi);
            int oi2 = await _context.Database.ExecuteSqlRawAsync("INSERT INTO [OrderItem] (OrderId, ProductId) VALUES ({0},{1})", oi1.OrderId, oi1.ProductId);
            if (oi2 != 1) return null;
            return vmoi;
        }
    }
}

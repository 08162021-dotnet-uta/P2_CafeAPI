using System;
using System.Collections.Generic;

#nullable disable

namespace Project1.ModelsLayer.EfModels
{
    public partial class StoresProduct
    {
        public StoresProduct()
        {
            ItemizedOrders = new HashSet<ItemizedOrder>();
        }

        public int StoreProductId { get; set; }
        public Guid StoreguidId { get; set; }
        public int StoreId { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<ItemizedOrder> ItemizedOrders { get; set; }
    }
}

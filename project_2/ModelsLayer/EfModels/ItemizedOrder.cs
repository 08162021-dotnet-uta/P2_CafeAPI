using System;
using System.Collections.Generic;

#nullable disable

namespace Project1.ModelsLayer.EfModels
{
    public partial class ItemizedOrder
    {
        public Guid ItemizedId { get; set; }
        public Guid OrderId { get; set; }
        public int CustomerId { get; set; }
        public int StoreProductId { get; set; }
        public int ProductId { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
        public virtual StoresProduct StoreProduct { get; set; }
    }
}

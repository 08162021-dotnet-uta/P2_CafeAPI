using System;
using System.Collections.Generic;

#nullable disable

namespace ModelsLayer.EfModels
{
    public partial class Product
    {
        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? Inventory { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}

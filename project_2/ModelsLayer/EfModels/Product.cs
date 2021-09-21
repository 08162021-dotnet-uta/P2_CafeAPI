using System;
using System.Collections.Generic;

#nullable disable

namespace Project1.ModelsLayer.EfModels
{
    public partial class Product
    {
        public Product()
        {
            ItemizedOrders = new HashSet<ItemizedOrder>();
            StoresProducts = new HashSet<StoresProduct>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductPicture { get; set; }
        public int ProductQuantity { get; set; }

        public virtual ICollection<ItemizedOrder> ItemizedOrders { get; set; }
        public virtual ICollection<StoresProduct> StoresProducts { get; set; }
    }
}

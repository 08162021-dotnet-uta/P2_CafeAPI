using System;
using System.Collections.Generic;

#nullable disable

namespace ModelsLayer.EfModels
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int NumberOfItems { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}

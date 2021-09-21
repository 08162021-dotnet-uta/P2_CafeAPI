using System;
using System.Collections.Generic;

#nullable disable

namespace Project1.ModelsLayer.EfModels
{
    public partial class Customer
    {
        public Customer()
        {
            ItemizedOrders = new HashSet<ItemizedOrder>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordH { get; set; }

        public virtual ICollection<ItemizedOrder> ItemizedOrders { get; set; }
    }
}

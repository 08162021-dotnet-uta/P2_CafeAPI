using System;
using System.Collections.Generic;

#nullable disable

namespace ModelsLayer.EfModels
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
            SignIns = new HashSet<SignIn>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<SignIn> SignIns { get; set; }
    }
}

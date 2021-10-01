using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace DatabaseLayer
{
    public partial class ViewModelProduct
    {
        // minimum required properties
        public ViewModelProduct(string id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        // no inventory
        public ViewModelProduct(string id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }

        // no description
        public ViewModelProduct(string id, string name, decimal price, int inventory)
        {
            Id = id;
            Name = name;
            Price = price;
            Inventory = inventory;
        }

        // all
        public ViewModelProduct(string id, string name, string description, decimal price, int inventory)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Inventory = inventory;
        }
        public ViewModelProduct() { }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? Inventory { get; set; }


    }
}

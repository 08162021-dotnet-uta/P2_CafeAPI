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
        public ViewModelProduct(string productId, string name, decimal price)
        {
            ProductId = productId;
            Name = name;
            Price = price;
        }

        // no description, no inventory
        public ViewModelProduct(int id, string productId, string name, decimal price)
        {
            Id = id;
            ProductId = productId;
            Name = name;
            Price = price;
        }

        // no id, no inventory
        public ViewModelProduct(string productId, string name, string description, decimal price)
        {
            ProductId = productId;
            Name = name;
            Description = description;
            Price = price;
        }

        // no id, no description
        public ViewModelProduct(string productId, string name, decimal price, int inventory)
        {
            ProductId = productId;
            Name = name;
            Price = price;
            Inventory = inventory;
        }

        // no id
        public ViewModelProduct(string productId, string name, string description, decimal price, int inventory)
        {
            ProductId = productId;
            Name = name;
            Description = description;
            Price = price;
            Inventory = inventory;
        }

        // all
        public ViewModelProduct(int id, string productId, string name, string description, decimal price, int inventory)
        {
            Id = id;
            ProductId = productId;
            Name = name;
            Description = description;
            Price = price;
            Inventory = inventory;
        }
        public ViewModelProduct() { }

        public int Id { get; set; }
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? Inventory { get; set; }


    }
}

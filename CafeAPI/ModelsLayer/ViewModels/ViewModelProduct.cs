using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer
{
    public partial class ViewModelProduct
    {
        //minimum required properties
        //public ViewModelProduct(string productid, string name, decimal price)
        //{
        //    productid = productid;
        //    name = name;
        //    price = price;
        //}

        ////no description, no inventory
        //public ViewModelProduct(int id, string productid, string name, decimal price)
        //{
        //    id = id;
        //    productid = productid;
        //    name = name;
        //    price = price;
        //}

        ////no id, no inventory
        //public ViewModelProduct(string productid, string name, string description, decimal price)
        //{
        //    productid = productid;
        //    name = name;
        //    description = description;
        //    price = price;
        //}

        ////no id, no description
        //public ViewModelProduct(string productid, string name, decimal price, int inventory)
        //{
        //    productid = productid;
        //    name = name;
        //    price = price;
        //    inventory = inventory;
        //}

        ////no id
        //public ViewModelProduct(string productid, string name, string description, decimal price, int inventory)
        //{
        //    productid = productid;
        //    name = name;
        //    description = description;
        //    price = price;
        //    inventory = inventory;
        //}

        ////all
        //public ViewModelProduct(int id, string productid, string name, string description, decimal price, int inventory)
        //{
        //    id = id;
        //    productid = productid;
        //    name = name;
        //    description = description;
        //    price = price;
        //    inventory = inventory;
        //}
        //public ViewModelProduct() { }

        public string Id { get; set; }
        //public string ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? Inventory { get; set; }
    }
}

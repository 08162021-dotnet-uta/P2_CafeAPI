using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseLayer
{
    public partial class ViewModelOrder
    {
        // minimum required properties
        public ViewModelOrder(int customerId, int numberOfItems, decimal totalPrice)
        {
            CustomerId = customerId;
            NumberOfItems = numberOfItems;
            TotalPrice = totalPrice;
        }

        // all
        public ViewModelOrder(int id, int customerId, int numberOfItems, decimal totalPrice)
        {
            Id = id;
            CustomerId = customerId;
            NumberOfItems = numberOfItems;
            TotalPrice = totalPrice;
        }
        public ViewModelOrder() { }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int NumberOfItems { get; set; }
        public decimal TotalPrice { get; set; }


    }
}

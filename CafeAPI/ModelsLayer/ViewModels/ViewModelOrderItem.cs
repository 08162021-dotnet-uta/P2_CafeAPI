using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseLayer
{
    public partial class ViewModelOrderItem
    {
        public ViewModelOrderItem(int id, int orderId, string productId)
        {
            Id = id;
            OrderId = orderId;
            ProductId = productId;
        }
        public ViewModelOrderItem() { }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public string ProductId { get; set; }


    }
}


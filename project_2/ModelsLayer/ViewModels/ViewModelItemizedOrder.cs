using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08162021batchDemoStore
{

    public class ViewModelItemizedOrder
    {
        public Guid ItemizedId { get; set; }
        public Guid OrderId { get; set; }
        public int CustomerId { get; set; }
        public int StoreProductId { get; set; }
        public int ProductId { get; set; }
        public DateTime OrderDate { get; set; }
        public ViewModelItemizedOrder() { }
    }
}

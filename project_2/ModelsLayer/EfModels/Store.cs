using System;
using System.Collections.Generic;

#nullable disable

namespace Project1.ModelsLayer.EfModels
{
    public partial class Store
    {
        public Store()
        {
            StoresProducts = new HashSet<StoresProduct>();
        }

        public int StoreId { get; set; }
        public string StoreName { get; set; }

        public virtual ICollection<StoresProduct> StoresProducts { get; set; }
    }
}

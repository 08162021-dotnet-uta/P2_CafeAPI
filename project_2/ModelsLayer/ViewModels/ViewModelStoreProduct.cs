using Project1.ModelsLayer.EfModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08162021batchDemoStore
{
    public class ViewModelStoreProduct
    {
        public int StoreProductId { get; set; }
        public Guid StoreguidId { get; set; }
        public int StoreId { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
        public ViewModelStoreProduct()

        {

        }
        public ViewModelStoreProduct(Guid storeguidId)
        
            {
                StoreguidId = storeguidId;
            }
        public ViewModelStoreProduct(int storeProductId, Guid storeguidId,int storeId,int productId)
        {
            StoreProductId = storeProductId;
            StoreguidId = storeguidId;
            StoreId = storeId;
            ProductId = productId;
        }
        public ViewModelStoreProduct( Guid storeguidId, int storeId, int productId)
        {
           StoreguidId = storeguidId;
            StoreId = storeId;
            ProductId = productId;
        }

    }
}

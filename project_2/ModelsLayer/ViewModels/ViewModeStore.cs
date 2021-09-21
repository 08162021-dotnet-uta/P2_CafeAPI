using System.ComponentModel.DataAnnotations;

namespace _08162021batchDemoStore
{
    public partial class ViewModelsStore
    {
        public ViewModelsStore()
        { }
            public ViewModelsStore(int storeid, string storeName)
        {
            StoreId = storeid;
            StoreName = storeName;
        }

        public int StoreId { get; set; }
        public string StoreName { get; set; }


    }
}

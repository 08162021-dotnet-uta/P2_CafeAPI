namespace _08162021batchDemoStore
{
	public class ViewModelProduct
	{
		public int ProductId { get; set; } = -1;
		public string ProductName { get; set; }
		public string ProductDescription { get; set; }
		public decimal ProductPrice { get; set; }
		public string ProductPicture { get; set; }
		public int ProductQuantity { get; set; }
		public ViewModelProduct()
        {

        }
		public ViewModelProduct( int productId, string productName, string productDescription, decimal productPrice, int productQuantity,string productPicture)
        {
			ProductId = productId;
			ProductName = productName;
			ProductDescription = productDescription;
			ProductPrice = productPrice;
			ProductQuantity = productQuantity;
			ProductPicture = productPicture;
        }
	}
}
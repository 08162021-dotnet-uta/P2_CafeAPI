using Project1.ModelsLayer.EfModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _08162021batchDemoStore
{
	public class ViewModelAll
	{
		//public IEnumerable<Product> ViewModelProducts { get; set; }
  //      public IEnumerable<Store> ViewModelStores { get; set; }
		//public IEnumerable<ItemizedOrder> ViewModelItemizedOrder { get; set; }
  //      public Tuple<List<Product>, List<ItemizedOrder>, List<Store>> getall { get;
		//	//{
		//	//	//ViewModelProducts = List<Product> v;ValueTuple

		//	//} 
		//	set; }
        private string fname;

		[StringLength(20, MinimumLength = 1)]
		public string Fname
		{
			get
			{
				return this.fname;
			}
			set
			{
				if (value.Length > 50 || value.Length == 0)
				{
					this.fname = "invalid Name Input";
				}
				else
				{
					this.fname = value;
				}
			}
		}
		public string Lname { get; set; }
		public string Email { get; set; }
		public string PasswordH { get; set; }
		public int CustomerId { get; set; }
		public Guid ItemizedId { get; set; }
		public Guid OrderId { get; set; }
		public int StoreProductId { get; set; }
		public int ProductId { get; set; }
		public DateTime OrderDate { get; set; }
		public string ProductName { get; set; }
		public string ProductDescription { get; set; }
		public decimal ProductPrice { get; set; }
		public string ProductPicture { get; set; }
		public int ProductQuantity { get; set; }
		public int StoreId { get; set; }
		public string StoreName { get; set; }
		public Guid StoreguidId { get; set; }
        public object AuthorBiographies { get; set; }

      

		


	}//EoC
}//EoN
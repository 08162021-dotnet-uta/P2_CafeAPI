export interface Product {
  asin: string;
  // id: string; // asin
  title: string; // name of product
  price: {
    value: number; // price of product not including '$'
    currency: string; // USD
  }
  image: string; // image link
}

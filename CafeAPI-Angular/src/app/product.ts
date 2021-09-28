export interface Product {
  // id: number;
  // name: string;

  id: string; // asin
  title: string; // name of product
  price: {
    value: number; // price of product
    currency: string; // USD
  }
  image: string; // image link
}

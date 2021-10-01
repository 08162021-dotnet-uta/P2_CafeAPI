export interface Order {
  customerId: number;
  numberOfItems: number;
  totalPrice: number;
  // this property in OrderItem Db table
  // productId: string;
}

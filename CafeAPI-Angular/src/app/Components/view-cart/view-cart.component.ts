import { Component, OnInit } from '@angular/core';
import { Customer } from 'src/app/Models/customer';
import { Order } from 'src/app/Models/order';
import { Product } from 'src/app/Models/product';
import { OrderService } from 'src/app/Services/order.service';

@Component({
  selector: 'app-view-cart',
  templateUrl: './view-cart.component.html',
  styleUrls: ['./view-cart.component.css'],
})
export class ViewCartComponent implements OnInit {
  //users cart, stored in sessionStorage
  cart: Product[] = [];
  //used to parse cart
  cartString?: string | null;
  // used to check if user is logged in
  loginString?: string | null;
  cartEmpty: string = 'Empty cart';
  isEmpty: boolean = true;
  order: Order = { customerId: 0, numberOfItems: 0, totalPrice: 0 };
  user!: Customer;
  totalPrice: number = 0;

  constructor(private orderService: OrderService) {}

  ngOnInit(): void {
    this.getCart();
  }

  loginStatus(): void {
    this.loginString = sessionStorage.getItem('user');
    if (this.loginString == null) {
      window.location.href = '/login';
    } else {
      this.placeOrder();
    }
  }

  // prints to the user their cart is empty
  printEmpty(): string {
    return this.cartEmpty;
  }

  // get the customer's cart stored in sessionStorage
  getCart(): void {
    this.cartString = sessionStorage.getItem('cart');
    if (this.cartString == null) {
      this.printEmpty();
    } else {
      this.isEmpty = !this.isEmpty;
      this.cart = JSON.parse(this.cartString);
    }
  }

  placeOrder(): void {
    if (this.loginString != null) {
      this.user = JSON.parse(this.loginString);
    }
    console.log(this.user);
    this.order.customerId = this.user.id;
    this.order.numberOfItems = this.cart.length;
    for (let item of this.cart) {
      this.totalPrice += item.price.value;
      // this.orderService.addOrderItem(item);
    }
    this.order.totalPrice = this.totalPrice;
    console.log(this.order);
    this.orderService.addOrder(this.order);
  }
}

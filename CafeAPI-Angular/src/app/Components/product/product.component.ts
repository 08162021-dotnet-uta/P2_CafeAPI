import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/Services/product.service';
import { Product } from 'src/app/Models/product';
import { JsonPipe } from '@angular/common';


@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  //product user clicked on has to be initialized
  product :Product = {id: "A1B2C3D4E5", title:"banana", price: { value: 2.99, currency: "USD"}, image: "https://cdn.mos.cms.futurecdn.net/42E9as7NaTaAi4A6JcuFwG-1200-80.jpg"}
  //whether or not the product is out of stock
  outOfStock?: boolean;
  //users cart, stored in sessionStorage
  cart : Product[]
  //used to parse cart
  cartString ?: string | null

  constructor(private productService: ProductService) {
    this.cart = []
  }

  ngOnInit(): void {
  }

  setOutOfStockBool(id: string): void{this.productService.outOfStock().subscribe(bool => this.outOfStock = bool)}

  addToCart(id: string) :void{

    this.cartString = sessionStorage.getItem("cart")

    if(this.cartString!=null) this.cart = JSON.parse(this.cartString);
    //user automatically has an empty cart in sessionStorage, as opposed to no cart at all
    else sessionStorage.setItem("cart",JSON.stringify(this.cart))

    this.setOutOfStockBool(id);
    if(!this.outOfStock) {this.cart.push(this.product); sessionStorage.setItem("cart",JSON.stringify(this.cart))}
  }

}
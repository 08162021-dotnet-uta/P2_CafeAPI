import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/Services/product.service';
import { Product } from 'src/app/Models/product';
import { JsonPipe } from '@angular/common';
//things to fake: product, sessionStorage(getitem,setitem), service call,

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  //product user clicked on
  product :Product = {id:-1,name:""}
  //whether or not the product is out of stock
  outOfStock?: boolean;
  //users cart, stored in sessionStorage
  cart : Product[]
  //used to parse cart
  cartString ?: string | null

  constructor(private productService: ProductService) {
    this.cartString = sessionStorage.getItem("cart") 
    this.cart = []
  }

  ngOnInit(): void {
    
  }

  setOutOfStockBool(id: number): void{this.productService.outOfStock().subscribe(bool => this.outOfStock = bool)}
  addToCart(id: number) :void{
    this.setOutOfStockBool(id);
    //1st case: user has a cart and item not out of stock, rest are self explanatory
    if(!this.outOfStock && this.cartString!=null) {this.cart = JSON.parse(this.cartString); this.cart.push(this.product); sessionStorage.setItem("cart",JSON.stringify(this.cart))}
    else if(!this.outOfStock && this.cartString==null) {this.cart.push(this.product); sessionStorage.setItem("cart",JSON.stringify(this.cart))} 
  }
  
}

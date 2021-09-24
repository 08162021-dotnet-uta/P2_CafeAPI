import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
import { Product } from '../product';
import { JsonPipe } from '@angular/common';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  product :Product 
  outOfStock?: boolean;
  cart : Product[]
  cartString ?: string | null

  constructor(private productService: ProductService) {
    //this is set based on which item was clicked
    this.product = {id:5,name:"fred"};
    this.cartString = sessionStorage.getItem("cart") 
    this.cart = []
  }

  ngOnInit(): void {
    
  }

  setOutOfStock(id: number): void{this.productService.outOfStock().subscribe(bool => this.outOfStock = bool)}
  addToCart(id: number) :void{
    this.setOutOfStock(id);
    if(!this.outOfStock && this.cartString!=null) {this.cart = JSON.parse(this.cartString); this.cart.push(this.product); sessionStorage.setItem("cart",JSON.stringify(this.cart))}
    else if(!this.outOfStock && this.cartString==null) {this.cart.push(this.product); sessionStorage.setItem("cart",JSON.stringify(this.cart))} 
    else console.log("Out of stock")
  }
  
}

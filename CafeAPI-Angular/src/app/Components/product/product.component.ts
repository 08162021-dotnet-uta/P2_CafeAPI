import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/Services/product.service';
import { Product } from 'src/app/Models/product';
import { JsonPipe } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';


@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  //product user clicked on has to be initialized
  product: Product = {
    asin: 'asflk', title: "banana", price: { value: 2.99, currency: "USD" }, image: "https://cdn.mos.cms.futurecdn.net/42E9as7NaTaAi4A6JcuFwG-1200-80.jpg"
  }
  //whether or not the product is out of stock
  outOfStock ?: boolean 
  //users cart, stored in sessionStorage
  cart: Product[]
  //used to parse cart
  cartString?: string | null

  constructor(
    private productService: ProductService,
    private route: ActivatedRoute,
    private location: Location
  ) {
    this.cart = []; this.setOutOfStockBool("aabb")
  }

  ngOnInit(): void {
    this.getProduct(); 
  }

  // gets a single product from the product list stored in the sessionStorage
  getProduct(): void {
    const id: string = this.route.snapshot.paramMap.get('id')!;
    console.log(id);
    const item = this.productService.getProduct(id);
    this.product = item;
  }

  goBack(): void {
    this.location.back();
  }

    setOutOfStockBool(id: string): void{this.productService.outOfStock(id).subscribe(bool => this.outOfStock = bool)}
  //setOutOfStockBool(id: string): boolean{let the : boolean = false;this.productService.outOfStock(id).subscribe(function(bool){the = bool;console.log(the,"in")}) 
    //console.log(the,"out"); return true;}
  //setOutOfStockBool(id: string): boolean{return this.pro outOfStock(id).pipe(map(bool => { return bool? true:false}));}

  // addToCart(id: string): void {

  //   this.cartString = sessionStorage.getItem("cart")

  //   if (this.cartString != null) this.cart = JSON.parse(this.cartString);
  //   //user automatically has an empty cart in sessionStorage, as opposed to no cart at all
  //   else sessionStorage.setItem("cart", JSON.stringify(this.cart))

  //   this.setOutOfStockBool(id);
  //   if (!this.outOfStock) { this.cart.push(this.product); sessionStorage.setItem("cart", JSON.stringify(this.cart)) }
  // }
  addToCart(): void {
    let id: string = 'aabb'
    this.cartString = sessionStorage.getItem("cart")

    if (this.cartString != null) this.cart = JSON.parse(this.cartString);
    //user automatically has an empty cart in sessionStorage, as opposed to no cart at all
    else sessionStorage.setItem("cart", JSON.stringify(this.cart))

    this.setOutOfStockBool(id);
    console.log(this.outOfStock)
    if (!this.outOfStock) { this.cart.push(this.product); sessionStorage.setItem("cart", JSON.stringify(this.cart)) }
  }

}

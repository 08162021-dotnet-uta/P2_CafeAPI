import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
import { Product } from '../product';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  outOfStock?: boolean;
  constructor(private productService: ProductService) {}

  ngOnInit(): void {
  }

  setOutOfStock(): void{this.productService.outOfStock().subscribe(bool => this.outOfStock = bool)}
  addToCart
  
}

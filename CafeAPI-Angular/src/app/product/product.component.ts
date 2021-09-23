import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  stockNotEmpty?: boolean;
  constructor(private productService: ProductService) {}

  ngOnInit(): void {
  }

  stock(): void{this.productService.stockNotEmpty()
                                   .subscribe(bool => this.stockNotEmpty = bool)
                                  }
  
}

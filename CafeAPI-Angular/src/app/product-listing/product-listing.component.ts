import { Component, Input, OnInit } from '@angular/core';
import { Product } from '../product';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-listing',
  templateUrl: './product-listing.component.html',
  styleUrls: ['./product-listing.component.css']
})
export class ProductListingComponent implements OnInit {
  @Input() searchTerm!: string;
  productlisting: Product[] = [];

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    // this.productService.getProductListing(this.searchTerm)
    //   .subscribe(productlisting => this.productlisting = productlisting);
  }

  getProductListing(searchTerm: string): void {
    this.productService.getProductListing(searchTerm)
      .subscribe(productlisting => this.productlisting = productlisting);
  }
  
}

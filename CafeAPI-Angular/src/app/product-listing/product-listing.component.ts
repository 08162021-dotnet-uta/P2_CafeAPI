import { Component, Input, OnInit } from '@angular/core';
import { Product } from '../product';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-listing',
  templateUrl: './product-listing.component.html',
  styleUrls: ['./product-listing.component.css']
})
export class ProductListingComponent implements OnInit {
  searchTerm!: string;
  productlisting$: Product[] = [];

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.searchTerm = this.productService.searchTerm;
    if (this.searchTerm != undefined)
    {
      this.getProductListing(this.searchTerm);
    }
  }

  getProductListing(searchTerm: string): void {
    this.productService.getProductListing(searchTerm)
      .subscribe(productlisting => this.productlisting$ = productlisting);
  }

}

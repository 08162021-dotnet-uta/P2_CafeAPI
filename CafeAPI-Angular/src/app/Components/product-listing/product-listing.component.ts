import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/Models/product';
import { ProductService } from 'src/app/Services/product.service';

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
    // retrieves stored and formatted search term from product service to be used here
    this.searchTerm = this.productService.searchTerm;
    if (this.searchTerm != undefined) {
      this.getProductListing(this.searchTerm);
    }
  }

  // method to call and retrieve product list from product service
  getProductListing(searchTerm: string): void {
    this.productService.getProductListing(searchTerm)
      .subscribe(productlisting => {
        this.productlisting$ = productlisting,
          // console.log(this.productlisting$),
          // sessionStorage.clear(),
          sessionStorage.setItem('results', JSON.stringify(productlisting)) // store the data into session storage
      });
  }

}

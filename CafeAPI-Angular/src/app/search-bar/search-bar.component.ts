import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.css']
})
export class SearchBarComponent implements OnInit {
  // searchTerm: string = "memory+cards";

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
  }

  // searchProducts(searchTerm: string): void {
  //   searchTerm.replace(" ","+");
  //   console.log(searchTerm);
  //   this.productService.getProductListing(searchTerm);
  // }

  formatInput(searchTerm: string): string {
    return searchTerm.replace(" ","+");
  }

}

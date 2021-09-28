import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.css']
})
export class SearchBarComponent implements OnInit {
  searchTerm!: string;

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
  }

  // searchProducts(searchTerm: string): void {
  //   searchTerm.replace(" ","+");
  //   console.log(searchTerm);
  //   this.productService.getProductListing(searchTerm);
  // }

  formatInput(searchTerm: string): string {
    this.searchTerm = this.productService.formatSearchTerm(searchTerm);
    console.log(this.searchTerm);
    return this.searchTerm;
  }

}

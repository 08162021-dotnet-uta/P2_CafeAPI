import { Injectable } from '@angular/core';
import { Observable,of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor() { }
  //The literal below will replaced by the result of the call to CafeAPI to see is the item is out-of-stock
  //In This is the other input for testing my add-to-cart FE functionality (the other being the "Add to cart" button in app.component)
  //Possible input values for testing: true,false
  outOfStock(): Observable<boolean>{return of(false)}
}

import { Injectable } from '@angular/core';
import { Observable,of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor() { }
  //boolean will be returned where literal is
  outOfStock(): Observable<boolean>{return of(false)}
}

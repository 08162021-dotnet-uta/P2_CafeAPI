import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Product } from '../Models/product';
import { ProductView } from '../Models/productView';
import {CafeAPIUrl} from './URLList'


@Injectable({
  providedIn: 'root'
})
export class ProductApiService {
  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  // create functions to make http requests 
  ProductList(): Observable<ProductView[]> {
    return this.http.get<ProductView[]>(`${CafeAPIUrl}/Product/list`);
  }


  getProduct(id: string): Observable<ProductView> {
    return this.http.get<ProductView>(`${CafeAPIUrl}/Product/detail/${id}`);
  }

  addProduct(product: ProductView): Observable<ProductView> {
    console.log("addProduct is working");
    // console.log(product);
    return this.http.post<ProductView>(`${CafeAPIUrl}/Product/register`, product, this.httpOptions);
    // .pipe(
    //   tap((newproduct: ProductView) => console.log(`Product added with id=${newproduct.id}`)),
    //   catchError(this.handleError<ProductView>('Error on Product'))
    // );
  }

  //The literal below will replaced by the result of the call to CafeAPI to see is the item is out-of-stock
  //In This is the other input for testing my add-to-cart FE functionality (the other being the "Add to cart" button in app.component)
  //Possible input values for testing: true,false
  outOfStock(productId:string): Observable<boolean>{
    return this.http.get<boolean>(`${CafeAPIUrl}outOfStock/${productId}`)
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      console.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}

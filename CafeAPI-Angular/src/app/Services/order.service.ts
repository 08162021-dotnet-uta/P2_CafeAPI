import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Product } from '../Models/product';
import { Order } from '../Models/order';
import { Observable } from 'rxjs/internal/Observable';
import { Customer } from '../Models/customer';
import { catchError, tap } from 'rxjs/operators';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private http: HttpClient) { }

  private url = 'http://localhost:5001';

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  // adds an order to the Order Db table
  addOrder(order: Order): Observable<Order> {
    return this.http.post<Order>(`${this.url}/Order/placeorder`, order, this.httpOptions).pipe(
      tap((order: Order) => console.log(`added order for customer w / id=${order.customerId}`)),
      catchError(this.handleError<Order>('addOrder'))
    );
  }

  // addOrderItem(product: Product): void {
  //   return this.http.post<Order
  // }

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

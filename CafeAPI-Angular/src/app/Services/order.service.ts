import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Product } from '../Models/product';
import { Order } from '../Models/order';
import { Observable } from 'rxjs/internal/Observable';
import { Customer } from '../Models/customer';
import { catchError, tap } from 'rxjs/operators';
import { of } from 'rxjs';
import { OrderItem } from '../Models/order-item';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  orderitem: OrderItem = { orderId:0, productId: ""};

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

  getOrders(customer: Customer): Observable<Order[]> {
    return this.http.get<Order[]>(`${this.url}/Order/orderlist/${customer.id}`)
    .pipe(
      catchError(this.handleError<Order[]>('getOrders', []))
    );
  }

  addOrderItem(orderId: number, productId: string): Observable<OrderItem> {
    this.orderitem.orderId = orderId; // I don't know how to retrieve the orderId as it's only in the Db
    this.orderitem.productId = productId;
    return this.http.post<OrderItem>(`${this.url}/OrderItem/addorderitem`, this.orderitem, this.httpOptions).pipe(
      tap((orderitem: OrderItem) => console.log(`added orderitem for order w / id=${orderitem.orderId}`)),
      catchError(this.handleError<OrderItem>('addOrderItem'))
    );
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

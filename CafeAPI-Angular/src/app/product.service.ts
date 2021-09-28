import { Injectable } from '@angular/core';
import { Observable, of} from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { catchError, map } from 'rxjs/operators';
import { Product } from './product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private apiUrl: string = `https://api.rainforestapi.com/request?api_key=4EEDADFC0F7B4CD3B0996DEA09B90586&type=search&amazon_domain=amazon.com&search_term=`;
  searchTerm!: string;

  constructor(private http: HttpClient) { }

  //boolean will be returned where literal is
  outOfStock(): Observable<boolean>{return of(false)}

  formatSearchTerm(searchTerm: string): string {
    this.searchTerm = searchTerm.replace(" ","+");
    return this.searchTerm;
  }

  // returns a list of products
  getProductListing(searchTerm: string): Observable<Product[]> {
    // const url: string = `type=search&amazon_domain=amazon.com&search_term=memory+cards&page=1`;
    console.log(`${this.apiUrl}${searchTerm}&page=1`);
    console.log(this.http.get(`${this.apiUrl}${searchTerm}&page=1`));
    return this.http.get<Product[]>(`${this.apiUrl}${searchTerm}&page=1`)
      .pipe(map((data: any) => data.search_results),
        catchError(this.handleError<Product[]>('getProductListing', []))
      );
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
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

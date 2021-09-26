import { Injectable } from '@angular/core';
import { InMemoryDbService } from 'angular-in-memory-web-api';
import { Customer } from './customer';

@Injectable({
  providedIn: 'root',
})
export class InMemoryDataService implements InMemoryDbService {
  createDb() {
    const customers = [
      { customerId: 1, fname: "mark", lname: "Moore" },
      { customerId: 2, fname: "Jeffrey", lname: "Moore" },
      { customerId: 3, fname: "Brian", lname: "Stockton" },
      { customerId: 4, fname: 'john5', lname: 'turning' }
    ];
    return { customers };
  }

  // Overrides the genId method to ensure that a hero always has an id.
  // If the heroes array is empty,
  // the method below returns the initial number (4).
  // if the heroes array is not empty, the method below returns the highest
  // hero id + 1.
  genId(customers: Customer[]): number {
    return customers.length > 0 ? Math.max(...customers.map(customer => customer.customerId)) + 1 : 1;
  }

}
import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Customer } from '../customer';
@Component({
  selector: 'app-login-customer',
  templateUrl: './login-customer.component.html',
  styleUrls: ['./login-customer.component.css']
})
export class LoginCustomerComponent implements OnInit {
  fname: string = '';
  lname: string = '';
  @Output() passNewCustomerToParent = new EventEmitter<Customer>();

  constructor() { }


  ngOnInit(): void {
  }

  logincustomer(): void {
    // in order to pass data up the component chain
    // you must emit an event from the child
    // that is caught by the parent and handled.
    let c: Customer = { fname: this.fname, lname: this.lname };
    console.log(`login customer is...${this.fname} ${this.lname}`)
    this.passNewCustomerToParent.emit(c);
  }
}

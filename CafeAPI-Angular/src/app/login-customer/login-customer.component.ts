import { Component, OnInit } from '@angular/core';
import { Customer } from '../customer';
import { CustomerService } from '../customer.service';

@Component({
  selector: 'app-login-customer',
  templateUrl: './login-customer.component.html',
  styleUrls: ['./login-customer.component.css']
})
export class LoginCustomerComponent implements OnInit {
  fname: string = '';
  lname: string = '';
  isVisible?: any;

  customerlist: Customer[] = [];
  selectedCustomer?: Customer;
  observablelist = this.customerService.CustomerList();

  constructor(private customerService: CustomerService) { }

  ngOnInit(): void {
    this.observablelist
      .subscribe(
        x => {
          this.customerlist = x
        });
  }

  logincustomer(): void {
    //find customer
    this.selectedCustomer = this.customerlist.find(x => x.fname === this.fname && x.lname === this.lname);
    //if customer is found
    if (this.selectedCustomer == null) {
      //Make the submit dissapear and reappear
      this.isVisible = 'hidden';
      console.log("error in logincustomer() in login-customer.component");
      setTimeout(() => {
        this.isVisible = 'visible';
        window.location.href = '/login'
      }, 2000);

    }
    else {
      sessionStorage.setItem('user', JSON.stringify(this.selectedCustomer));
      window.location.href = '/';
    }
  }


}

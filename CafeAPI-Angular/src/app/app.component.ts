import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Customer } from './customer';
import { ProductComponent } from './product/product.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'appComponent'

  constructor(public router: Router) { }
}

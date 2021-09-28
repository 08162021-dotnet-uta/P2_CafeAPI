import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginCustomerComponent } from './login-customer/login-customer.component';
import { ProductListingComponent } from './product-listing/product-listing.component';
import { RegisterCustomerComponent } from './register-customer/register-customer.component';

const routes: Routes = [
  { path: '', redirectTo: `/`, pathMatch: 'full' },
  { path: `register`, component: RegisterCustomerComponent },
  { path: `login`, component: LoginCustomerComponent },
  { path: 'productlist', component: ProductListingComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginCustomerComponent } from './Components/login-customer/login-customer.component';
import { RegisterCustomerComponent } from './Components/register-customer/register-customer.component';
import { ProductListingComponent } from './Components/product-listing/product-listing.component';
import { ProductComponent } from './Components/product/product.component';

const routes: Routes = [
  { path: '', redirectTo: `/`, pathMatch: 'full' },
  { path: `register`, component: RegisterCustomerComponent },
  { path: 'productlist', component: ProductListingComponent },
  { path: 'product/:id', component: ProductComponent },
  { path: `login`, component: LoginCustomerComponent }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

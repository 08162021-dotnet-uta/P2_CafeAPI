import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ProductComponent } from './product/product.component';
import { AppRoutingModule } from './app-routing.module';
import { MenuSideBarComponent } from './menu-side-bar/menu-side-bar.component';
import { LoginCustomerComponent } from './login-customer/login-customer.component';
import { RegisterCustomerComponent } from './register-customer/register-customer.component';
import { ReactiveFormsModule } from '@angular/forms';
import { SearchBarComponent } from './search-bar/search-bar.component';


@NgModule({
  declarations: [
    AppComponent,
    MenuSideBarComponent,
    LoginCustomerComponent,
    RegisterCustomerComponent,
    SearchBarComponent,
    ProductComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

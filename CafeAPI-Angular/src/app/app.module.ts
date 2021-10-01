import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from 'src/app/Components/app/app.component';
import { AppRoutingModule } from './app-routing.module';
import { MenuSideBarComponent } from './Components/menu-side-bar/menu-side-bar.component';
import { LoginCustomerComponent } from './Components/login-customer/login-customer.component';
import { RegisterCustomerComponent } from './Components/register-customer/register-customer.component';
import { ReactiveFormsModule } from '@angular/forms';
// import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';
// import { InMemoryDataService } from './in-memory-data.service';
import { ProductComponent } from './Components/product/product.component';
import { SearchBarComponent } from './Components/search-bar/search-bar.component';
import { ProductListingComponent } from './Components/product-listing/product-listing.component';
import { ViewCartComponent } from './Components/view-cart/view-cart.component';
import { ProductApiService } from './Services/product-api.service';

@NgModule({
  declarations: [
    AppComponent,
    MenuSideBarComponent,
    LoginCustomerComponent,
    RegisterCustomerComponent,
    ProductComponent,
    SearchBarComponent,
    ProductListingComponent,
    ViewCartComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

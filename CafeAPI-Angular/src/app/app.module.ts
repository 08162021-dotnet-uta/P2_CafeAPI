import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from 'src/app/Components/app/app.component';
import { AppRoutingModule } from './app-routing.module';
import { ProductComponent } from './Components/product/product.component';
import { SearchBarComponent } from './Components/search-bar/search-bar.component';
import { ProductListingComponent } from './Components/product-listing/product-listing.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductComponent,
    SearchBarComponent,
    ProductListingComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

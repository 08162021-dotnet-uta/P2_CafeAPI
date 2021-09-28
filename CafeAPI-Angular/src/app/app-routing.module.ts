import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductListingComponent } from './Components/product-listing/product-listing.component';

const routes: Routes = [
  { path: '', redirectTo: `/`, pathMatch: 'full' },
  { path: 'productlist', component: ProductListingComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

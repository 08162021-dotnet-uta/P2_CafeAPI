import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductComponent } from './product.component';
import {ProductService} from "src/app/Services/product.service"
import { Observable,of } from 'rxjs';
import {Product} from "src/app/Models/product"
//things being faked to test 'Add_item_to_cart': product, sessionStorage(getitem,setitem), service call

describe('ProductComponent', () => {
  let component: ProductComponent;
  let service: ProductService
  let fixture: ComponentFixture<ProductComponent>;
  let map = new Map();

  // beforeEach(async () => {
  //   await TestBed.configureTestingModule({
  //     declarations: [ ProductComponent ]
  //   })
  //   .compileComponents();
  // });

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductComponent ],
      providers: [ ProductService ]})
    fixture = TestBed.createComponent(ProductComponent);
    service = fixture.debugElement.injector.get(ProductService);
    component = fixture.componentInstance;
    component.product = {id: 10, name:"pineapple"}
    fixture.detectChanges();
  });
  
  beforeAll(()=>{
    // Mock localStorage
    spyOn(sessionStorage, 'getItem').and.callFake( (key:string):any => {
     let val = map.get(key);
     if(val == undefined) return null
     else return val
    });
    
    spyOn(sessionStorage, 'setItem').and.callFake((key:string, value:string) =>  {
      map.set(key,value);
    });
    
    spyOn(sessionStorage, 'clear').and.callFake(() =>  {
        map.clear()
    });
  });
  
  //things relevant to testing 'Add_item_to_cart':out of stock, not out of stock, cart empty, cart not empty, no cart to begin with
  it('when out of stock and user never had a cart to begin with, cart remains empty', () => {
    spyOn(service, 'outOfStock').and.returnValue(of(true)); 
    component.addToCart(component.product.id)
    expect(JSON.parse(map.get("cart")).length).toBe(0)
    map.clear()
  });
  
  it('when in stock and cart not empty, cart will contain an aditional item', () => {
    let cart : Product[] = [{id:4, name:"soap"},{id:5,name:"sun glasses"}]
    map.set("cart",JSON.stringify(cart))
    spyOn(service, 'outOfStock').and.returnValue(of(false)); 
    component.addToCart(component.product.id)
    expect(JSON.parse(map.get("cart")).length).toEqual(3)
    map.clear()
  });
  
  //automatically generated test
  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { LoginCustomerComponent } from './login-customer.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ReactiveFormsModule } from '@angular/forms';
import { CustomerService } from '../customer.service';
import { httpClientInMemBackendServiceFactory } from 'angular-in-memory-web-api';


describe('Component: Login', () => {

  let component: LoginCustomerComponent;
  let fixture: ComponentFixture<LoginCustomerComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ReactiveFormsModule, FormsModule, HttpClientTestingModule],
      declarations: [LoginCustomerComponent]
    });

    // create component and test fixture
    fixture = TestBed.createComponent(LoginCustomerComponent);
    TestBed.configureTestingModule({ providers: [CustomerService] });



    // get test component from the fixture
    component = fixture.componentInstance;

    component.ngOnInit();
    // component.customerlist = [
    //   { customerId: 1, fname: "mark", lname: "Moore" },
    //   { customerId: 2, fname: "Jeffrey", lname: "Moore" },
    //   { customerId: 3, fname: "Brian", lname: "Stockton" },
    //   { customerId: 4, fname: 'john5', lname: 'turning' }
    // ];
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component.customerlist).toBeTruthy();
  });
  it('fname is not defined', () => {
    expect(component.fname).toBeDefined();
  });
  it('lname is not defined', () => {
    expect(component.lname).toBeDefined();
  });


});
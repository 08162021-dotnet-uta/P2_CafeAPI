import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-menu-side-bar',
  templateUrl: './menu-side-bar.component.html',
  styleUrls: ['./menu-side-bar.component.css']
})
export class MenuSideBarComponent implements OnInit {
  widthVal?: any;
  constructor() { }

  ngOnInit(): void {
  }
  onMenu() {
    this.widthVal = '250px';
  }
  offMenu() {
    this.widthVal = '0px';
  }

}

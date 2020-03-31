import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-left-nav',
  templateUrl: './left-nav.component.html',
  styleUrls: ['./left-nav.component.css']
})
export class LeftNavComponent implements OnInit {

  navLinks = [
    {
      text: "test 1",
      fontAwesomeCss: "far fa-flag"
    },
    {
      text: "test 2",
      fontAwesomeCss: "far fa-map"
    },
    {
      text: "test 3",
      fontAwesomeCss: "far fa-wrench"
    }
  ];

  constructor() { }

  ngOnInit() {
  }

}

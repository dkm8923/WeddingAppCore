import { Component, OnInit } from '@angular/core';
import { NavLink } from '../../model/shell/nav/NavLink';
//import { NavLinkSection } from '../../model/shell/nav/NavLinkSection';

@Component({
  selector: 'app-left-nav',
  templateUrl: './left-nav.component.html',
  styleUrls: ['./left-nav.component.css']
})
export class LeftNavComponent implements OnInit {

  //navLinkSection: NavLinkSection;
  navLinks: NavLink[];
  
  constructor() {
    this.navLinks = [
      {
        text: "Usa State",
        fontAwesomeCss: "far fa-flag",
        url: "/usa-state"
      },
      {
        text: "Address",
        fontAwesomeCss: "far fa-map",
        url: "/address"
      }
    ];

    //this.navLinkSection = {
    //  sectionText: "Administration",
    //  navLinks: this.navLinks
    //};
  }

  ngOnInit() {
  }

}

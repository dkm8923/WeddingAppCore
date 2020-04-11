import { Component, OnInit } from '@angular/core';

import { LeftNavBaseModel } from '../../model/shell/left-nav/LeftNavBaseModel';
import { NavLinkSection } from '../../model/shell/nav/NavLinkSection';
import { NavLink } from '../../model/shell/nav/NavLink';
import { NavLinkUserProfile } from '../../model/shell/nav/NavLinkUserProfile';
import { NavLinkHome } from '../../model/shell/nav/NavLinkHome';
import { LayoutBaseModel } from '../../model/shell/LayoutBaseModel';

@Component({
  selector: 'app-shell-layout-base',
  templateUrl: './shell-layout-base.component.html',
  styleUrls: ['./shell-layout-base.component.css']
})
export class ShellLayoutBaseComponent implements OnInit {

  layoutBaseModel: LayoutBaseModel;
  leftNavBaseModel: LeftNavBaseModel;
  navLinkSections: NavLinkSection[] = [];
  navLinks: NavLink[] = [];

  constructor() {

    this.navLinks.push(new NavLink("Usa State", "/usa-state", "far fa-flag"));
    this.navLinks.push(new NavLink("Address", "/address", "far fa-map"));

    this.navLinkSections.push(new NavLinkSection("Administration", this.navLinks));

    this.leftNavBaseModel = new LeftNavBaseModel(
      this.navLinkSections,
      new NavLinkHome("assets/dist/img/AdminLTELogo.png", "Admin UI Test"),
      new NavLinkUserProfile("assets/dist/img/user2-160x160.jpg", "Faggy McFaggetson 123")
    );

    this.layoutBaseModel = {
      leftNavBaseModel: this.leftNavBaseModel
    };

    console.log("layoutBaseModel");
    console.log(this.layoutBaseModel);
  }

  ngOnInit() {
  }

}

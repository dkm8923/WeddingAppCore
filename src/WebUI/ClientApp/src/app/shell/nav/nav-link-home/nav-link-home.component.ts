import { Component, OnInit, Input } from '@angular/core';
import { NavLinkHome } from '../../../model/shell/nav/NavLinkHome';

@Component({
  selector: 'app-nav-link-home',
  templateUrl: './nav-link-home.component.html',
  styleUrls: ['./nav-link-home.component.css']
})
export class NavLinkHomeComponent implements OnInit {

  @Input() navLinkHome: NavLinkHome;

  constructor() { }

  ngOnInit() {
  }

}

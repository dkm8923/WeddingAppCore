import { Component, Input } from '@angular/core';
import { NavLink } from '../../../model/shell/nav/NavLink';

@Component({
  selector: 'app-nav-link-single',
  templateUrl: './nav-link-single.component.html',
  styleUrls: ['./nav-link-single.component.css']
})
export class NavLinkSingleComponent {
  @Input() navLink: NavLink;
}

import { Component, Input } from '@angular/core';
import { NavLinkSection } from '../../../model/shell/nav/NavLinkSection';

@Component({
  selector: 'app-nav-link-section-header',
  templateUrl: './nav-link-section-header.component.html',
  styleUrls: ['./nav-link-section-header.component.css']
})
export class NavLinkSectionHeaderComponent {
  @Input() navLinkSection: NavLinkSection;
}

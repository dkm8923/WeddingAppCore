import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-nav-link-section-header',
  templateUrl: './nav-link-section-header.component.html',
  styleUrls: ['./nav-link-section-header.component.css']
})
export class NavLinkSectionHeaderComponent {
  @Input() text: string;
}

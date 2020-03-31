import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-nav-link-section-tree-view',
  templateUrl: './nav-link-section-tree-view.component.html',
  styleUrls: ['./nav-link-section-tree-view.component.css']
})
export class NavLinkSectionTreeViewComponent {
  @Input() text: string;
  @Input() fontAwesomeCss: string;
  @Input() navLinks: [];
}

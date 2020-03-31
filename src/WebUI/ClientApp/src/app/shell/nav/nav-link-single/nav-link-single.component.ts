import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-nav-link-single',
  templateUrl: './nav-link-single.component.html',
  styleUrls: ['./nav-link-single.component.css']
})
export class NavLinkSingleComponent {

  @Input() text: string;
  @Input() fontAwesomeCss: string;
  @Input() badgeText: string;
}

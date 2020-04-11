import { Component, OnInit, Input } from '@angular/core';
import { NavLinkUserProfile } from '../../../model/shell/nav/NavLinkUserProfile';

@Component({
  selector: 'app-nav-link-user-profile',
  templateUrl: './nav-link-user-profile.component.html',
  styleUrls: ['./nav-link-user-profile.component.css']
})
export class NavLinkUserProfileComponent implements OnInit {

  @Input() navLinkUserProfile: NavLinkUserProfile

  constructor() { }

  ngOnInit() {
  }

}

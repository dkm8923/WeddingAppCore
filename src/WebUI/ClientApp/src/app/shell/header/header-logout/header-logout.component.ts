import { Component } from '@angular/core';
import { AuthorizeService } from '../../../../api-authorization/authorize.service';

@Component({
  selector: 'app-header-logout',
  templateUrl: './header-logout.component.html',
  styleUrls: ['./header-logout.component.css']
})
export class HeaderLogoutComponent {
  authorizeSvc: AuthorizeService

  logOut() {
    this.authorizeSvc.signOut();
  }
}

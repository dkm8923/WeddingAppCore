import { Component } from '@angular/core';
import { ShellLayoutBaseComponent } from './shell/shell-layout-base/shell-layout-base.component';
import { AppGlobalService } from './shared/services/app-global/app-global.service'
import { AuthorizeService } from '../api-authorization/authorize.service';
import { UtilityService } from './core/utility.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  appGlobalSvc: AppGlobalService;
  //isAuthenticated = false;
  isAuthenticated;
  private user;

  constructor(
    appGlobalSvc: AppGlobalService,
    authorizeSvc: AuthorizeService,
    utilSvc: UtilityService
  ) {
    this.appGlobalSvc = appGlobalSvc;
    //console.log("appGlobalSvc from app component");
    //console.log(this.appGlobalSvc.userInfo);
    //console.log(this.appGlobalSvc.isAuthenticated);

    

    //console.log("isAuthenticated from app Component");
    //console.log(this.isAuthenticated);

    //authorizeSvc.signOut();

    this.isAuthenticated = authorizeSvc.isAuthenticated().subscribe(data => {
      console.log("isAuthenticated from app Component");
      console.log(data); //You will get all your user related information in this field
    });

    if (!this.isAuthenticated) {
      //user is not authenticated, fall back to login process
      console.log("User Not Authenticated");
      utilSvc.navigateRouter('login');
    }
  }
}

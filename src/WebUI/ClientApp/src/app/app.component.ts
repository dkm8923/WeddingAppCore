import { Component } from '@angular/core';
import { ShellLayoutBaseComponent } from './shell/shell-layout-base/shell-layout-base.component';
//import { AppGlobalService } from './shared/services/app-global/app-global.service'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  //appGlobalSvc: AppGlobalService;

  title = 'app';

  //constructor(appGlobalSvc: AppGlobalService) {
  //  this.appGlobalSvc = appGlobalSvc;
  //  console.log("appGlobalSvc from app component");
  //  console.log(appGlobalSvc);
  //}
}

import { ApplicationSettingsBaseComponent } from './application-settings/application-settings-base/application-settings-base.component';
import { AuthorizeGuard } from '../../api-authorization/authorize.guard';

export const ShellRoutes = [
  { path: '', component: ApplicationSettingsBaseComponent, canActivate: [AuthorizeGuard] }//,
  //{ path: 'create', component: UsaStateCreateEditComponent, canActivate: [AuthorizeGuard] },
  //{ path: 'edit/:id', component: UsaStateCreateEditComponent, canActivate: [AuthorizeGuard] },
  //{ path: 'delete/:id', component: UsaStateDeleteComponent, canActivate: [AuthorizeGuard] }
];

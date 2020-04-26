import { ApplicationSettingsBaseComponent } from './application-settings/application-settings-base/application-settings-base.component';

import { ApplicationRoutes } from './application-settings/application/application.routes';
import { ReferenceTypeRoutes } from './application-settings/reference-type/reference-type.routes';

import { AuthorizeGuard } from '../../api-authorization/authorize.guard';

export const ShellRoutes = [
  { path: '', component: ApplicationSettingsBaseComponent, canActivate: [AuthorizeGuard] },
  //{ path: 'application', component: ApplicationBaseComponent, canActivate: [AuthorizeGuard] },
  { path: 'application', children: ApplicationRoutes, canActivate: [AuthorizeGuard] },
  { path: 'reference-type', children: ReferenceTypeRoutes, canActivate: [AuthorizeGuard] }
];

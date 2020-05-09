import { AppSettingsBaseComponent } from './application-settings/app-settings/app-settings-base/app-settings-base.component';

import { AppSettingsRoutes } from './application-settings/app-settings/app-settings.routes';
import { ApplicationRoutes } from './application-settings/application/application.routes';
import { ReferenceTypeRoutes } from './application-settings/reference-type/reference-type.routes';
import { NavLinkRoutes } from './application-settings/nav-link/nav-link.routes';
import { NavLinkSectionRoutes } from './application-settings/nav-link-section/nav-link-section.routes';

import { AuthorizeGuard } from '../../api-authorization/authorize.guard';

export const ShellRoutes = [
  { path: '', component: AppSettingsBaseComponent, canActivate: [AuthorizeGuard] },
  //{ path: 'application', component: ApplicationBaseComponent, canActivate: [AuthorizeGuard] },
  { path: 'app-settings', children: AppSettingsRoutes, canActivate: [AuthorizeGuard] },
  { path: 'application', children: ApplicationRoutes, canActivate: [AuthorizeGuard] },
  { path: 'reference-type', children: ReferenceTypeRoutes, canActivate: [AuthorizeGuard] },
  { path: 'nav-link', children: NavLinkRoutes, canActivate: [AuthorizeGuard] },
  { path: 'nav-link-section', children: NavLinkSectionRoutes, canActivate: [AuthorizeGuard] }
];

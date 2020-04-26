import { AppSettingsBaseComponent, AppSettingsDeleteComponent, AppSettingsCreateEditComponent } from '../app-settings';
import { AuthorizeGuard } from '../../../../api-authorization/authorize.guard';

export const AppSettingsRoutes = [
  { path: '', component: AppSettingsBaseComponent, canActivate: [AuthorizeGuard] },
  { path: 'create', component: AppSettingsCreateEditComponent, canActivate: [AuthorizeGuard] },
  { path: 'edit/:id', component: AppSettingsCreateEditComponent, canActivate: [AuthorizeGuard] },
  { path: 'delete/:id', component: AppSettingsDeleteComponent, canActivate: [AuthorizeGuard] }
];

import { ApplicationBaseComponent, ApplicationDeleteComponent, ApplicationCreateEditComponent } from '../application';
import { AuthorizeGuard } from '../../../../api-authorization/authorize.guard';

export const ApplicationRoutes = [
  { path: '', component: ApplicationBaseComponent, canActivate: [AuthorizeGuard] },
  { path: 'create', component: ApplicationCreateEditComponent, canActivate: [AuthorizeGuard] },
  { path: 'edit/:id', component: ApplicationCreateEditComponent, canActivate: [AuthorizeGuard] },
  { path: 'delete/:id', component: ApplicationDeleteComponent, canActivate: [AuthorizeGuard] }
];

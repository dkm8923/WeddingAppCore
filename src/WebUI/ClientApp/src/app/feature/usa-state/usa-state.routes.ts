import { UsaStateBaseComponent, UsaStateDeleteComponent, UsaStateCreateEditComponent } from '../usa-state';
import { AuthorizeGuard } from '../../../api-authorization/authorize.guard';

export const UsaStateRoutes = [
  { path: '', component: UsaStateBaseComponent, canActivate: [AuthorizeGuard] },
  { path: 'create', component: UsaStateCreateEditComponent, canActivate: [AuthorizeGuard] },
  { path: 'edit/:id', component: UsaStateCreateEditComponent, canActivate: [AuthorizeGuard] },
  { path: 'delete/:id', component: UsaStateDeleteComponent, canActivate: [AuthorizeGuard] }
];

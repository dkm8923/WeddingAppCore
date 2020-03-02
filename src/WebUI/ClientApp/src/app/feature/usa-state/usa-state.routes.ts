import { UsaStateBaseComponent } from './usa-state-base/usa-state-base.component';
import { UsaStateDeleteComponent } from './usa-state-delete/usa-state-delete.component';
import { UsaStateCreateEditComponent } from './usa-state-create-edit/usa-state-create-edit.component';
import { AuthorizeGuard } from '../../../api-authorization/authorize.guard';

export const UsaStateRoutes = [
  { path: '', component: UsaStateBaseComponent, canActivate: [AuthorizeGuard] },
  { path: 'create', component: UsaStateCreateEditComponent, canActivate: [AuthorizeGuard] },
  { path: 'edit/:id', component: UsaStateCreateEditComponent, canActivate: [AuthorizeGuard] },
  { path: 'delete/:id', component: UsaStateDeleteComponent, canActivate: [AuthorizeGuard] }
];

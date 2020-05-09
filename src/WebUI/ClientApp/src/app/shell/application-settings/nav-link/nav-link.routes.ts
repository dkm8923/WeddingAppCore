import { NavLinkBaseComponent, NavLinkDeleteComponent, NavLinkCreateEditComponent } from '../nav-link';
import { AuthorizeGuard } from '../../../../api-authorization/authorize.guard';

export const NavLinkRoutes = [
  { path: '', component: NavLinkBaseComponent, canActivate: [AuthorizeGuard] },
  { path: 'create', component: NavLinkCreateEditComponent, canActivate: [AuthorizeGuard] },
  { path: 'edit/:id', component: NavLinkCreateEditComponent, canActivate: [AuthorizeGuard] },
  { path: 'delete/:id', component: NavLinkDeleteComponent, canActivate: [AuthorizeGuard] }
];

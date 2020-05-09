import { NavLinkSectionBaseComponent, NavLinkSectionDeleteComponent, NavLinkSectionCreateEditComponent } from '../nav-link-section';
import { AuthorizeGuard } from '../../../../api-authorization/authorize.guard';

export const NavLinkSectionRoutes = [
  { path: '', component: NavLinkSectionBaseComponent, canActivate: [AuthorizeGuard] },
  { path: 'create', component: NavLinkSectionCreateEditComponent, canActivate: [AuthorizeGuard] },
  { path: 'edit/:id', component: NavLinkSectionCreateEditComponent, canActivate: [AuthorizeGuard] },
  { path: 'delete/:id', component: NavLinkSectionDeleteComponent, canActivate: [AuthorizeGuard] }
];

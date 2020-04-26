import { ReferenceTypeBaseComponent, ReferenceTypeDeleteComponent, ReferenceTypeCreateEditComponent } from '../reference-type';
import { AuthorizeGuard } from '../../../../api-authorization/authorize.guard';

export const ReferenceTypeRoutes = [
  { path: '', component: ReferenceTypeBaseComponent, canActivate: [AuthorizeGuard] },
  { path: 'create', component: ReferenceTypeCreateEditComponent, canActivate: [AuthorizeGuard] },
  { path: 'edit/:id', component: ReferenceTypeCreateEditComponent, canActivate: [AuthorizeGuard] },
  { path: 'delete/:id', component: ReferenceTypeDeleteComponent, canActivate: [AuthorizeGuard] }
];

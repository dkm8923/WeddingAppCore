import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthorizeGuard } from '../api-authorization/authorize.guard';

import { ShellRoutes } from './shell/shell.routes';
import { HomeRoutes } from './feature/home/home.routes';
import { UsaStateRoutes } from './feature/usa-state/usa-state.routes';

const routes: Routes = [
  { path: 'application-settings', children: ShellRoutes, canActivate: [AuthorizeGuard] },
  { path: 'home', children: HomeRoutes, canActivate: [AuthorizeGuard] },
  { path: 'usa-state', children: UsaStateRoutes, canActivate: [AuthorizeGuard] },
  // otherwise redirect to home
  { path: '**', redirectTo: 'home' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: []
})
export class AppRoutingModule { }

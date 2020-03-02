import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeRoutes } from './feature/home/home.routes';
import { UsaStateRoutes } from './feature/usa-state/usa-state.routes';

const routes: Routes = [
  // Fallback when no prior route is matched
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  //{ path: 'home', component: HomeComponent, pathMatch: 'full' },
  { path: 'home', children: HomeRoutes },
  { path: 'usa-state', children: UsaStateRoutes }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: []
})
export class AppRoutingModule { }

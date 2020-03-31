import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { ShellLayoutBaseComponent } from './shell-layout-base/shell-layout-base.component';
import { FooterComponent } from './footer/footer.component';
import { HeaderComponent } from './header/header.component';
import { LeftNavComponent } from './left-nav/left-nav.component';
import { RightMenuComponent } from './right-menu/right-menu.component';
import { NavLinkSingleComponent } from './nav/nav-link-single/nav-link-single.component';
import { NavLinkSectionHeaderComponent } from './nav/nav-link-section-header/nav-link-section-header.component';
import { NavLinkSectionTreeViewComponent } from './nav/nav-link-section-tree-view/nav-link-section-tree-view.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule
  ],
  declarations: [
    FooterComponent,
    HeaderComponent,
    LeftNavComponent,
    RightMenuComponent,
    ShellLayoutBaseComponent,
    NavLinkSingleComponent,
    NavLinkSectionHeaderComponent,
    NavLinkSectionTreeViewComponent
  ],
  exports: [
    FooterComponent,
    HeaderComponent,
    LeftNavComponent,
    RightMenuComponent,
    ShellLayoutBaseComponent
  ]
})
export class ShellModule {}

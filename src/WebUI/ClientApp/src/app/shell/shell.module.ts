import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { ShellLayoutBaseComponent } from './shell-layout-base/shell-layout-base.component';
import { FooterComponent } from './footer/footer.component';
import { LeftNavComponent } from './left-nav/left-nav.component';
import { RightMenuComponent } from './right-menu/right-menu.component';
import { NavLinkSingleComponent } from './nav/nav-link-single/nav-link-single.component';
import { NavLinkSectionHeaderComponent } from './nav/nav-link-section-header/nav-link-section-header.component';
import { NavLinkSectionTreeViewComponent } from './nav/nav-link-section-tree-view/nav-link-section-tree-view.component';
import { NavLinkHomeComponent } from './nav/nav-link-home/nav-link-home.component';
import { NavLinkUserProfileComponent } from './nav/nav-link-user-profile/nav-link-user-profile.component';
import { HeaderSearchFormComponent } from './header/header-search-form/header-search-form.component';
import { HeaderMessageMenuComponent } from './header/header-message-menu/header-message-menu.component';
import { HeaderNotificationMenuComponent } from './header/header-notification-menu/header-notification-menu.component';
import { HeaderRightMenuToggleComponent } from './header/header-right-menu-toggle/header-right-menu-toggle.component';
import { HeaderBaseComponent } from './header/header-base/header-base.component';
import { LayoutColorSelectorComponent } from './layout-color-selector/layout-color-selector.component';
import { HeaderMessageComponent } from './header/header-message/header-message.component';
import { HeaderNotificationComponent } from './header/header-notification/header-notification.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule
  ],
  declarations: [
    FooterComponent,
    LeftNavComponent,
    RightMenuComponent,
    ShellLayoutBaseComponent,
    NavLinkSingleComponent,
    NavLinkSectionHeaderComponent,
    NavLinkSectionTreeViewComponent,
    NavLinkHomeComponent,
    NavLinkUserProfileComponent,
    HeaderSearchFormComponent,
    HeaderMessageMenuComponent,
    HeaderNotificationMenuComponent,
    HeaderRightMenuToggleComponent,
    HeaderBaseComponent,
    LayoutColorSelectorComponent,
    HeaderMessageComponent,
    HeaderNotificationComponent
  ],
  exports: [
    FooterComponent,
    LeftNavComponent,
    RightMenuComponent,
    ShellLayoutBaseComponent
  ]
})
export class ShellModule {}

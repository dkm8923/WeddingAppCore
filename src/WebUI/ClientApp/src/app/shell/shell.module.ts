import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { SharedModule } from '../shared/shared.module';

import { ErrorLogService } from '../core';

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
import { ApplicationBaseComponent } from './application-settings/application/application-base/application-base.component';
import { ApplicationCreateEditComponent } from './application-settings/application/application-create-edit/application-create-edit.component';
import { ApplicationDeleteComponent } from './application-settings/application/application-delete/application-delete.component';
import { ReferenceTypeBaseComponent } from './application-settings/reference-type/reference-type-base/reference-type-base.component';
import { ReferenceTypeCreateEditComponent } from './application-settings/reference-type/reference-type-create-edit/reference-type-create-edit.component';
import { ReferenceTypeDeleteComponent } from './application-settings/reference-type/reference-type-delete/reference-type-delete.component';
import { AppSettingsBaseComponent } from './application-settings/app-settings/app-settings-base/app-settings-base.component';
import { AppSettingsCreateEditComponent } from './application-settings/app-settings/app-settings-create-edit/app-settings-create-edit.component';
import { AppSettingsDeleteComponent } from './application-settings/app-settings/app-settings-delete/app-settings-delete.component';
import { NavLinkBaseComponent } from './application-settings/nav-link/nav-link-base/nav-link-base.component';
import { NavLinkCreateEditComponent } from './application-settings/nav-link/nav-link-create-edit/nav-link-create-edit.component';
import { NavLinkDeleteComponent } from './application-settings/nav-link/nav-link-delete/nav-link-delete.component';
import { NavLinkSectionBaseComponent } from './application-settings/nav-link-section/nav-link-section-base/nav-link-section-base.component';
import { NavLinkSectionCreateEditComponent } from './application-settings/nav-link-section/nav-link-section-create-edit/nav-link-section-create-edit.component';
import { NavLinkSectionDeleteComponent } from './application-settings/nav-link-section/nav-link-section-delete/nav-link-section-delete.component';
import { HeaderLogoutComponent } from './header/header-logout/header-logout.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    SharedModule
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
    HeaderNotificationComponent,
    ApplicationBaseComponent,
    ApplicationCreateEditComponent,
    ApplicationDeleteComponent,
    ReferenceTypeBaseComponent,
    ReferenceTypeCreateEditComponent,
    ReferenceTypeDeleteComponent,
    AppSettingsBaseComponent,
    AppSettingsCreateEditComponent,
    AppSettingsDeleteComponent,
    NavLinkBaseComponent,
    NavLinkCreateEditComponent,
    NavLinkDeleteComponent,
    NavLinkSectionBaseComponent,
    NavLinkSectionCreateEditComponent,
    NavLinkSectionDeleteComponent,
    HeaderLogoutComponent
  ],
  exports: [
    FooterComponent,
    LeftNavComponent,
    RightMenuComponent,
    ShellLayoutBaseComponent
  ],
  providers: [
    ErrorLogService
  ]
})
export class ShellModule {}

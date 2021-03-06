import { Component, OnInit } from '@angular/core';

import { AppGlobalService } from '../../shared/services/app-global/app-global.service'

import { LeftNavBaseModel } from '../../model/shell/left-nav/LeftNavBaseModel';
import { NavLinkSection } from '../../model/shell/nav/NavLinkSection';
import { NavLink } from '../../model/shell/nav/NavLink';
import { NavLinkUserProfile } from '../../model/shell/nav/NavLinkUserProfile';
import { NavLinkHome } from '../../model/shell/nav/NavLinkHome';
import { LayoutBaseModel } from '../../model/shell/LayoutBaseModel';
import { UiAppSettingFooterDto } from '../../model/dto/wedding-api-models'
import { HeaderBaseModel } from '../../model/shell/header/HeaderBaseModel';
import { HeaderMessage } from '../../model/shell/header/HeaderMessage';
import { HeaderNotification } from '../../model/shell/header/HeaderNotification';

@Component({
  selector: 'app-shell-layout-base',
  templateUrl: './shell-layout-base.component.html',
  styleUrls: ['./shell-layout-base.component.css']
})
export class ShellLayoutBaseComponent implements OnInit {

  appGlobalSvc: AppGlobalService;
  commonData: any;

  layoutBaseModel: LayoutBaseModel;
  footerBaseModel: UiAppSettingFooterDto;
  headerBaseModel: HeaderBaseModel;
  headerMessageArr: HeaderMessage[] = [];
  headerNotificationArr: HeaderNotification[] = [];
  leftNavBaseModel: LeftNavBaseModel;
  navLinkSections: NavLinkSection[] = [];
  navLinks: NavLink[] = [];

  constructor(
    appGlobalSvc: AppGlobalService
  ) {

    this.commonData = appGlobalSvc.getCommonData();

    console.log("appGlobalSvc from Shell layout base");
    console.log(appGlobalSvc);
    console.log(this.commonData);

    this.navLinks.push(new NavLink("Usa State", "/usa-state", "far fa-flag"));
    this.navLinks.push(new NavLink("Address", "/address", "far fa-map"));

    this.navLinkSections.push(new NavLinkSection("Administration", this.navLinks));

    this.navLinkSections.push(new NavLinkSection("Application Settings", [
      new NavLink("Customize Layout", "/application-settings", "far fa-edit"),
      new NavLink("Customize App", "/application-settings/app-settings", "far fa-edit"),
      new NavLink("Application Editor", "/application-settings/application", "far fa-edit"),
      new NavLink("Reference Type Editor", "/application-settings/reference-type", "far fa-edit"),
      new NavLink("Nav Link Editor", "/application-settings/nav-link", "far fa-edit"),
      new NavLink("Nav Link Section Editor", "/application-settings/nav-link-section", "far fa-edit")
    ]));

    this.leftNavBaseModel = new LeftNavBaseModel(
      this.navLinkSections,
      new NavLinkHome("assets/dist/img/AdminLTELogo.png", "Admin UI Test"),
      new NavLinkUserProfile("assets/dist/img/user2-160x160.jpg", "Test User 123")
    );

    //this.footerBaseModel = new UiAppSettingFooterDto({ textLeft: this.commonData.layoutData.footer.textLeft, textMiddle: this.commonData.layoutData.footer.textMiddle, textRight: this.commonData.layoutData.footer.textRight });
    this.footerBaseModel = new UiAppSettingFooterDto({ textLeft: "test 1", textMiddle: "test 2", textRight: "test 3" });

    this.headerMessageArr.push(new HeaderMessage("Brad Diesel", "assets/dist/img/user1-128x128.jpg", "Call me whenever you can...", "4 Hours Ago"));
    this.headerMessageArr.push(new HeaderMessage("John Pierce", "assets/dist/img/user8-128x128.jpg", "I got your message bro", "3 Hours Ago"));
    this.headerMessageArr.push(new HeaderMessage("Nora Silvester", "assets/dist/img/user3-128x128.jpg", "Yo, yo, wut up", "2 Hours Ago"));
    this.headerMessageArr.push(new HeaderMessage("Bob Smith", "assets/dist/img/user6-128x128.jpg", "Yo, Fuck You", "4 Hours Ago"));
    this.headerMessageArr.push(new HeaderMessage("Bob Smith", "assets/dist/img/user6-128x128.jpg", "I'm Talking To YOU", "3 Hours Ago"));
    this.headerMessageArr.push(new HeaderMessage("Bob Smith", "assets/dist/img/user6-128x128.jpg", "YEAH YOU!!!", "2 Hours Ago"));

    this.headerNotificationArr.push(new HeaderNotification(1, "Friend Request(s)", "fas fa-envelope", "4 Hours Ago"));
    this.headerNotificationArr.push(new HeaderNotification(2, "Report(s)", "fas fa-users", "4 Hours Ago"));
    this.headerNotificationArr.push(new HeaderNotification(3, "Errors(s)", "fas fa-file", "4 Hours Ago"));

    this.headerBaseModel = new HeaderBaseModel(true, true, true, true, this.headerMessageArr, this.headerNotificationArr);

    this.layoutBaseModel = {
      leftNavBaseModel: this.leftNavBaseModel,
      footerBaseModel: this.footerBaseModel,
      headerBaseModel: this.headerBaseModel
    };

    console.log("layoutBaseModel");
    console.log(this.layoutBaseModel);
  }

  ngOnInit() {
  }

}

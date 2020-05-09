import { Component } from '@angular/core';
import { UiAppSettingNavLinkSectionClient, UiAppSettingNavLinkSectionDto } from "../../../../model/dto/wedding-api-models";

@Component({
  selector: 'app-nav-link-section-base',
  templateUrl: './nav-link-section-base.component.html',
  styleUrls: ['./nav-link-section-base.component.css']
})
export class NavLinkSectionBaseComponent {

  public data: UiAppSettingNavLinkSectionDto[];

  constructor(private client: UiAppSettingNavLinkSectionClient) {
    client.getAll().subscribe(result => {
      this.data = result;
      console.log("NavLinkSections");
      console.log(this.data);
    }, error => console.error(error));
  }
}

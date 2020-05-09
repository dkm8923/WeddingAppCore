import { Component } from '@angular/core';
import { UiAppSettingNavLinkClient, UiAppSettingNavLinkDto } from "../../../../model/dto/wedding-api-models";

@Component({
  selector: 'app-nav-link-base',
  templateUrl: './nav-link-base.component.html',
  styleUrls: ['./nav-link-base.component.css']
})
export class NavLinkBaseComponent {

  public data: UiAppSettingNavLinkDto[];

  constructor(private client: UiAppSettingNavLinkClient) {
    client.getAll().subscribe(result => {
      this.data = result;
      console.log("NavLinks");
      console.log(this.data);
    }, error => console.error(error));
  }
}

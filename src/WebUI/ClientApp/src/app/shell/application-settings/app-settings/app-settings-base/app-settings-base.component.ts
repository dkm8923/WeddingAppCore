import { Component } from '@angular/core';
import { UiAppSettingClient, UiAppSettingDto } from "../../../../model/dto/wedding-api-models";

@Component({
  selector: 'app-app-settings-base',
  templateUrl: './app-settings-base.component.html',
  styleUrls: ['./app-settings-base.component.css']
})
export class AppSettingsBaseComponent {

  public data: UiAppSettingDto[];

  constructor(private client: UiAppSettingClient) {
    client.getAll().subscribe(result => {
      this.data = result;
      console.log("App Settings");
      console.log(this.data);
    }, error => console.error(error));
  }

}

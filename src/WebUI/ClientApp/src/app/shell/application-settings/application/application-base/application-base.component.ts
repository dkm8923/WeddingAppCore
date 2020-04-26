import { Component } from '@angular/core';
import { UiAppSettingApplicationClient, UiAppSettingApplicationDto } from "../../../../model/dto/wedding-api-models";

@Component({
  selector: 'app-application-base',
  templateUrl: './application-base.component.html',
  styleUrls: ['./application-base.component.css']
})
export class ApplicationBaseComponent {

  public data: UiAppSettingApplicationDto[];

  constructor(private client: UiAppSettingApplicationClient) {
    client.getAll().subscribe(result => {
      this.data = result;
      console.log("Applications");
      console.log(this.data);
    }, error => console.error(error));
  }
}

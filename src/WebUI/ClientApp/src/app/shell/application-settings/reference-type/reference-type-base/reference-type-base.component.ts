import { Component } from '@angular/core';
import { UiAppSettingReferenceTypeClient, UiAppSettingReferenceTypeDto } from "../../../../model/dto/wedding-api-models";

@Component({
  selector: 'app-reference-type-base',
  templateUrl: './reference-type-base.component.html',
  styleUrls: ['./reference-type-base.component.css']
})
export class ReferenceTypeBaseComponent {

  public data: UiAppSettingReferenceTypeDto[];

  constructor(private client: UiAppSettingReferenceTypeClient) {
    client.getAll().subscribe(result => {
      this.data = result;
      console.log("ReferenceTypes");
      console.log(this.data);
    }, error => console.error(error));
  }
}

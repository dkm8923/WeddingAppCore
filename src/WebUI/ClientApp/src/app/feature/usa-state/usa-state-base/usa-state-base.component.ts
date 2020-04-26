import { Component } from '@angular/core';
import { UsaStateClient, UsaStateDto } from "../../../model/dto/wedding-api-models";

@Component({
  selector: 'app-usa-state-base',
  templateUrl: './usa-state-base.component.html',
  styleUrls: ['./usa-state-base.component.css']
})
export class UsaStateBaseComponent {
  public data: UsaStateDto[];

  constructor(private client: UsaStateClient) {
    client.getAll().subscribe(result => {
      this.data = result;
      console.log("Usa States");
      console.log(this.data);
    }, error => console.error(error));
  }
}

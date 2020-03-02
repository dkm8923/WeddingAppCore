import { Component } from '@angular/core';
import { UsaStateClient, UsaStateDto } from "../../../Model/dto/wedding-api-models";

@Component({
  selector: 'app-usa-state-base',
  templateUrl: './usa-state-base.component.html',
  styleUrls: ['./usa-state-base.component.css']
})
export class UsaStateBaseComponent {
  public states: UsaStateDto[];

  constructor(private client: UsaStateClient) {
    client.getAll().subscribe(result => {
      this.states = result;
      console.log("Usa States");
      console.log(this.states);
    }, error => console.error(error));
  }
}

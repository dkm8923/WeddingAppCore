import { Component, Input } from '@angular/core';
import { faPlus } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-button-create',
  template: '<button type="submit" class="btn btn-success btn-icon-text"><fa-icon [icon]="faPlus"></fa-icon>{{buttonText}}</button>'
})

export class ButtonCreateComponent {

  @Input() buttonText: string;

  faPlus = faPlus;

  constructor() {
    if (!this.buttonText) {
      this.buttonText = "Create New Record";
    }
  }
}

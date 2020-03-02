import { Component, Input } from '@angular/core';
import { faTimes } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-button-cancel',
  template: '<button type="submit" class="btn btn-danger btn-icon-text"><fa-icon [icon]="faTimes"></fa-icon>{{buttonText}}</button>'
})

export class ButtonCancelComponent {

  @Input() buttonText: string;

  faTimes = faTimes;

  constructor() {
    if (!this.buttonText) {
      this.buttonText = "Cancel";
    }

  }
}

import { Component, Input } from '@angular/core';
import { faSave } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-button-save',
  template: '<button type="submit" class="btn btn-success btn-icon-text"><fa-icon [icon]="faSave"></fa-icon>{{buttonText}}</button>'
})

export class ButtonSaveComponent {
  
  @Input() buttonText: string;

  faSave = faSave;

  constructor() {
    if (!this.buttonText)
    {
      this.buttonText = "Save";
    }
    
  }
}

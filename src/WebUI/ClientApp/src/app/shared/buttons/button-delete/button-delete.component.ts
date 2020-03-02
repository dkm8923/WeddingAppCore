import { Component, Input } from '@angular/core';
import { faTrash } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-button-delete',
  template: '<button type="submit" class="btn btn-primary btn-icon-text"><fa-icon [icon]="faTrash"></fa-icon>{{buttonText}}</button>'
})

export class ButtonDeleteComponent {
  
  @Input() buttonText: string;

  faTrash = faTrash;

  constructor() {
    if (!this.buttonText)
    {
      this.buttonText = "Delete";
    }
    
  }
}

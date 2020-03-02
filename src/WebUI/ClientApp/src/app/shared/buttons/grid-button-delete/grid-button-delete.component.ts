import { Component, Input } from '@angular/core';
import { faTrash } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-grid-button-delete',
  template: '<button class="btn btn-danger grid-btn-icon" title="Delete Record"><fa-icon [icon]="faTrash"></fa-icon>{{buttonText}}</button>'
})

export class GridButtonDeleteComponent {

  faTrash = faTrash;
}

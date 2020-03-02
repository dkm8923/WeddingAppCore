import { Component, Input } from '@angular/core';
import { faEdit } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-grid-button-edit',
  template: '<button class="btn btn-warning grid-btn-icon" title="Edit Record"><fa-icon [icon]="faEdit"></fa-icon>{{buttonText}}</button>'
})

export class GridButtonEditComponent {

  faEdit = faEdit;
}

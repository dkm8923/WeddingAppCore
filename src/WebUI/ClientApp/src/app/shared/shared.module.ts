import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import {
  //form validation
  FieldErrorDisplayComponent,
  //loading spinner
  LoadingSpinnerComponent, 
  //buttons
  ButtonSaveComponent,
  ButtonDeleteComponent,
  ButtonCancelComponent,
  ButtonCreateComponent,
  GridButtonEditComponent,
  GridButtonDeleteComponent
} from '../shared';

@NgModule({
  imports: [
    CommonModule,
    FontAwesomeModule,
  ],
  declarations: [
    FieldErrorDisplayComponent,
    LoadingSpinnerComponent,
    ButtonSaveComponent,
    ButtonDeleteComponent,
    ButtonCancelComponent,
    ButtonCreateComponent,
    GridButtonEditComponent,
    GridButtonDeleteComponent
  ],
  exports: [
    FieldErrorDisplayComponent,
    LoadingSpinnerComponent,
    ButtonSaveComponent,
    ButtonDeleteComponent,
    ButtonCancelComponent,
    ButtonCreateComponent,
    GridButtonEditComponent,
    GridButtonDeleteComponent
  ],
  providers: []
})
export class SharedModule { }

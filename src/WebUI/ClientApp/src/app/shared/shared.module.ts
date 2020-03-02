import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

//form validation
import { FieldErrorDisplayComponent } from './form-elements/validation/field-error-display/field-error-display.component';

//loading spinner
import { LoadingSpinnerComponent } from './loading-spinner/loading-spinner.component';

//buttons
import { ButtonSaveComponent } from './buttons/button-save/button-save.component';
import { ButtonDeleteComponent } from './buttons/button-delete/button-delete.component';
import { ButtonCancelComponent } from './buttons/button-cancel/button-cancel.component';
import { ButtonCreateComponent } from './buttons/button-create/button-create.component';
import { GridButtonEditComponent } from './buttons/grid-button-edit/grid-button-edit.component';
import { GridButtonDeleteComponent } from './buttons/grid-button-delete/grid-button-delete.component';

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

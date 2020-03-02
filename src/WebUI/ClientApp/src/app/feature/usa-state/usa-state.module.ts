import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { SharedModule } from '../../shared/shared.module';

import { UsaStateService } from './usa-state.service';
import { ErrorLogService } from '../../core/error-log.service';

import { UsaStateBaseComponent } from './usa-state-base/usa-state-base.component';
import { UsaStateCreateEditComponent } from './usa-state-create-edit/usa-state-create-edit.component';
import { UsaStateDeleteComponent } from './usa-state-delete/usa-state-delete.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    SharedModule
  ],
  declarations: [
    UsaStateBaseComponent,
    UsaStateCreateEditComponent,
    UsaStateDeleteComponent
  ],
  providers: [
    UsaStateService,
    ErrorLogService
  ]
})
export class UsaStateModule { }

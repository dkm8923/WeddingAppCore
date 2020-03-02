import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { SharedModule } from '../../shared';

import { ErrorLogService } from '../../core';

import { UsaStateService, UsaStateBaseComponent, UsaStateCreateEditComponent, UsaStateDeleteComponent } from '../usa-state';

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

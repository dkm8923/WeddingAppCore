import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { SharedModule } from '../../shared';

import { ErrorLogService } from '../../core';

import { HomeBaseComponent } from '../home';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    SharedModule
  ],
  declarations: [
    HomeBaseComponent
  ],
  providers: [
    ErrorLogService
  ]
})
export class HomeModule { }

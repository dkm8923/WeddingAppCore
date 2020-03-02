import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { SharedModule } from '../../shared/shared.module';

import { ErrorLogService } from '../../core/error-log.service';

import { HomeBaseComponent } from './home-base/home-base.component';

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

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule  } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';

import { UtilityService, ErrorLogService } from './core';

import { SharedModule } from './shared/shared.module';
import { ShellModule } from './shell/shell.module';

import { HomeModule } from './feature/home/home.module';
import { UsaStateModule } from './feature/usa-state/usa-state.module';

import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ApiAuthorizationModule,
    ReactiveFormsModule,
    SharedModule,
    ShellModule,
    HomeModule,
    UsaStateModule,
    RouterModule,
    BrowserAnimationsModule,
    AppRoutingModule // must be imported as the last module as it contains the fallback route
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    UtilityService,
    ErrorLogService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

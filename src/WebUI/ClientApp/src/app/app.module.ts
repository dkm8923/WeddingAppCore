import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { ReactiveFormsModule  } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';

import { UtilityService, ErrorLogService } from './core';
import { AppGlobalService } from './shared/services/app-global/app-global.service'

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
    ErrorLogService,
    AppGlobalService,
    { provide: APP_INITIALIZER, useFactory: appGlobalProviderFactory, deps: [AppGlobalService], multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }


export function appGlobalProviderFactory(provider: AppGlobalService) {
  return () => provider.loadInitData();
}

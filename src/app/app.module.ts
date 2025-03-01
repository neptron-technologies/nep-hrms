import { HttpClient, HttpClientModule, provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS } from '@angular/common/http'; //added

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashboardComponent } from './Dashb/dashboard/dashboard.component';
import { LoginComponent } from './core/LoginPg/login/login.component';
import { CoreInterceptor } from './core/interceptors/interceptor-core';
//import { HttpClientModule } from '@angular/common/http';

@NgModule({ 
    declarations: [AppComponent,],
    bootstrap: [AppComponent,], 
    imports: [BrowserModule,AppRoutingModule,], 
    providers: [provideHttpClient(withInterceptorsFromDi())] })

export class AppModule { }


providers: [
    { provide: HTTP_INTERCEPTORS, useClass: CoreInterceptor, multi: true }
  ]
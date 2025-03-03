import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS } from '@angular/common/http'; //added

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreInterceptor } from './core/interceptors/interceptor-core';

@NgModule({ 
    declarations: [AppComponent,],
    bootstrap: [AppComponent,], 
    imports: [BrowserModule,AppRoutingModule,], 
    providers: [provideHttpClient(withInterceptorsFromDi())] })
export class AppModule { }


providers: [
    { 
        provide: HTTP_INTERCEPTORS, 
        useClass: CoreInterceptor, 
        multi: true },
        {
            provider: HTTP_INTERCEPTORS,
            useClass: CoreInterceptor,
            multi: true
        },
  ]
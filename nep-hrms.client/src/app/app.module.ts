import { HttpClient, HttpClientModule, withInterceptorsFromDi } from '@angular/common/http';
import { Injectable, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS } from '@angular/common/http'; //added
import { provideHttpClient } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashboardComponent } from './Dashb/dashboard/dashboard.component';
import { LoginComponent } from './core/LoginPg/login/login.component';
import { CoreInterceptor } from './core/interceptors/interceptor-core';
import { EmployeeComponent } from './core/Module/employee/employee.component';
import { AttendanceComponent } from './core/Module/attendance/attendance.component';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Validators } from '@angular/forms';
import { HttpHeaders } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ApplyleaveComponent } from './core/Module/applyleave/applyleave.component';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { ManageleaveComponent } from './core/Module/manageleave/manageleave.component';
import { EmpdashboardComponent } from './core/Module/empdashboard/empdashboard.component'
import {MatCardModule } from '@angular/material/card';

//import { HttpClientModule } from '@angular/common/http';

@NgModule({
    declarations: [AppComponent, EmployeeComponent, AttendanceComponent, ApplyleaveComponent,ManageleaveComponent, EmpdashboardComponent,],
    bootstrap: [AppComponent],
    imports: [BrowserModule, AppRoutingModule, ReactiveFormsModule,NgxChartsModule, BrowserAnimationsModule, MatCardModule,],
    providers: [provideHttpClient(withInterceptorsFromDi()), provideHttpClient()]
})
export class AppModule { };
// providers: [
//     { provide: HTTP_INTERCEPTORS, useClass: CoreInterceptor, multi: true }
//   ]
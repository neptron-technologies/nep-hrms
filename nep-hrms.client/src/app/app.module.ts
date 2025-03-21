import { HttpClient, withInterceptorsFromDi, withFetch } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { Injectable, NgModule } from '@angular/core';
import { NgModel } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
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
import { ProjectManagerComponent } from './core/Module/projectmanager/projectmanager.component';
import { RecruitmentComponent } from './core/Module/recruitment/recruitment.component';

@NgModule({
    declarations: [AppComponent, EmployeeComponent, AttendanceComponent, RecruitmentComponent,],
    bootstrap: [AppComponent],
    imports: [BrowserModule, AppRoutingModule, ReactiveFormsModule, CommonModule, HttpClientModule],
    providers: [provideHttpClient(withInterceptorsFromDi()), provideHttpClient(), provideHttpClient(withFetch())]
})
export class AppModule { };
// providers: [
//     { provide: HTTP_INTERCEPTORS, useClass: CoreInterceptor, multi: true }
//   ]
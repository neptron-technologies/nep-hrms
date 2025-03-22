import { withInterceptorsFromDi } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { provideHttpClient } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmployeeComponent } from './core/Module/employee/employee.component';
import { AttendanceComponent } from './core/Module/attendance/attendance.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule, DatePipe } from '@angular/common';
import { PayslipComponent } from './core/Module/payslip/payslip.component';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ApplyleaveComponent } from './core/Module/applyleave/applyleave.component';
import { ManageleaveComponent } from './core/Module/manageleave/manageleave.component';
import { EmpdashboardComponent } from './core/Module/empdashboard/empdashboard.component'
import {MatCardModule } from '@angular/material/card';
import { SuperadminComponent } from './core/Module/superadmin/superadmin.component';


//import { HttpClientModule } from '@angular/common/http';

@NgModule({
    declarations: [AppComponent, EmployeeComponent, PayslipComponent, ApplyleaveComponent, ManageleaveComponent, EmpdashboardComponent, SuperadminComponent],
    bootstrap: [AppComponent],
    imports: [BrowserModule, AppRoutingModule, 
        ReactiveFormsModule, AttendanceComponent, 
        CommonModule, 
        NgxChartsModule, 
        BrowserAnimationsModule, 
        MatCardModule
    ],
    providers: [provideHttpClient(withInterceptorsFromDi()), provideHttpClient(), DatePipe]
})
export class AppModule { };
// providers: [
//     { provide: HTTP_INTERCEPTORS, useClass: CoreInterceptor, multi: true }
//   ]

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
//import { HttpClientModule } from '@angular/common/http';

@NgModule({
    declarations: [AppComponent, EmployeeComponent, PayslipComponent, ],
    bootstrap: [AppComponent],
    imports: [BrowserModule, AppRoutingModule, 
        ReactiveFormsModule, AttendanceComponent, 
        CommonModule
        
        
    ],
    providers: [provideHttpClient(withInterceptorsFromDi()), provideHttpClient(), DatePipe]
})
export class AppModule { };
// providers: [
//     { provide: HTTP_INTERCEPTORS, useClass: CoreInterceptor, multi: true }
//   ]

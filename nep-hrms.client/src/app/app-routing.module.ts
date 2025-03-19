import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './core/LoginPg/login/login.component';
import { DashboardComponent } from './Dashb/dashboard/dashboard.component';
import { AuthGuard } from './core/auth/auth.guard';
import { EmployeeComponent } from './core/Module/employee/employee.component';
import { AttendanceComponent } from './core/Module/attendance/attendance.component';
import { SuperadminComponent } from './core/Module/superadmin/superadmin.component';
import { PayslipComponent } from './core/Module/payslip/payslip.component';
const routes: Routes = [
  {
    path: '',
    component: LoginComponent
  },
  {
    path: '',
    component: DashboardComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: 'dashboard',
        component: DashboardComponent
      },
      {
        path: 'employee',
        component: EmployeeComponent
      },
      {
        path: 'attendance',
        component: AttendanceComponent
      },
      {
        path: 'superadmin',
        component: SuperadminComponent
      },
      {
        path: 'payslip',
        component: PayslipComponent
      }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './core/LoginPg/login/login.component';
import { DashboardComponent } from './Dashb/dashboard/dashboard.component';
import { AuthGuard } from './core/auth/auth.guard';
import { EmployeeComponent } from './core/Module/employee/employee.component';
import { AttendanceComponent } from './core/Module/attendance/attendance.component';
import { PayslipComponent } from './core/Module/payslip/payslip.component';

const routes: Routes = [
  {
    path: '',
    component: LoginComponent
  },
  { path: 'login', loadComponent: () => import('./core/LoginPg/login/login.component').then(m => m.LoginComponent) },
  {
    // path: 'dashboard', loadComponent: () => import('./Dashb/dashboard/dashboard.component').then(m => m.DashboardComponent), canActivate: [AuthGuard], 

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
        path: 'payslip',
        component: PayslipComponent
      },
      {
        path: '**',
        redirectTo: 'login'
      }

    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

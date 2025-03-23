import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './core/LoginPg/login/login.component';
import { DashboardComponent } from './Dashb/dashboard/dashboard.component';
import { AuthGuard } from './core/auth/auth.guard';
import { EmployeeComponent } from './core/Module/employee/employee.component';
import { AttendanceComponent } from './core/Module/attendance/attendance.component';
import { PayslipComponent } from './core/Module/payslip/payslip.component';
import { ApplyleaveComponent } from './core/Module/applyleave/applyleave.component';
import { ManageleaveComponent } from './core/Module/manageleave/manageleave.component';
import { EmpdashboardComponent } from './core/Module/empdashboard/empdashboard.component';
import { SuperadminComponent } from './core/Module/superadmin/superadmin.component';
import { RecruitmentComponent } from './core/Module/recruitment/recruitment.component';

const routes: Routes = [
  {
    path: '',
    component: LoginComponent
  },
  { path: 'login', loadComponent: () => import('./core/LoginPg/login/login.component').then(m => m.LoginComponent) },
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
        path: 'payslip',
        component: PayslipComponent
      },
      {
        path: 'applyleave',
        component: ApplyleaveComponent
      },
      {
        path: 'manageleave',
        component: ManageleaveComponent
      },
      {
        path: 'empdashborad',
        component: EmpdashboardComponent
      },
      {
        path: 'superadmin',
        component: SuperadminComponent
      },
      {
        path: 'recruitment',
        component: RecruitmentComponent
      },
      {
        path: '**',
        redirectTo: 'login'
      },
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

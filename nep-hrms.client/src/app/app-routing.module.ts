import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './core/LoginPg/login/login.component';
import { DashboardComponent } from './Dashb/dashboard/dashboard.component';
import { AuthGuard } from './core/auth/auth.guard';
import { EmployeeComponent } from './core/Module/employee/employee.component';
import { AttendanceComponent } from './core/Module/attendance/attendance.component';
import { ProjectManagerComponent } from './core/Module/projectmanager/projectmanager.component';
import { RecruitmentComponent } from './core/Module/recruitment/recruitment.component';

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
        path: 'recruitment', 
        component: RecruitmentComponent 
      },
      {
        path: 'projectmanager',
        component: ProjectManagerComponent
      }
      // { 
      //   path: '', 
      //   redirectTo: 'recruitment', 
      //   pathMatch: 'full' 
      // }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
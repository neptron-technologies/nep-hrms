import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './core/LoginPg/login/login.component';
import { DashboardComponent } from './Dashb/dashboard/dashboard.component';
import { AuthGuard } from './core/auth/auth.guard';
import { EmployeeComponent } from './core/employee/employee.component';

const routes: Routes = [
  { 
    path: '', 
    redirectTo: 'login',
    pathMatch: 'full'
  },
  { 
    path: 'login', 
    component: LoginComponent,
  },
  { 
    path: '', 
    component: DashboardComponent, 
    canActivate: [AuthGuard],
    children:[
      {
        path: 'dashboard',
        component: DashboardComponent
      },
      {
        path: 'employee',
        component: EmployeeComponent    
      }
      
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

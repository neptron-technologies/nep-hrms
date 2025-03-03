import { Component } from '@angular/core';
import { LoginService } from '../../core/services/service-login.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {
  constructor(private authService: LoginService) {}

  logout(): void {
    this.authService.logout();
  }
}

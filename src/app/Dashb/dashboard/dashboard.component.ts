import { Component, inject, HostListener } from '@angular/core';
import { LoginService } from '../../core/services/service-login.service';
import { RouterLink, RouterOutlet } from '@angular/router';
import { Location } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-dashboard',
  imports: [RouterOutlet, RouterLink, MatIconModule],
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {
  constructor(private authService: LoginService, private location: Location) {}

  router = inject(RouterOutlet);
  onLogout(): void {
    this.authService.logout();
  }

  @HostListener('window:popstate', ['$event'])
  onPopState(event: Event): void {
    this.onLogout();
  }
}

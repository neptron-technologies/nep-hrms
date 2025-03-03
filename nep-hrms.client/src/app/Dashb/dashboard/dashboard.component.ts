import { Component, importProvidersFrom, HostListener } from '@angular/core';
import { LoginService } from '../../core/services/service-login.service';
import { Location } from '@angular/common';
import { RouterLink, RouterOutlet } from '@angular/router';
 
@Component({
  selector: 'app-dashboard',
  imports: [RouterOutlet, RouterLink],
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {
  constructor(private authService: LoginService, private location: Location) {}
 
  logout(): void {
    this.authService.logout();
  }
 
  @HostListener('window:popstate', ['$event'])
  onPopState(event: Event): void {
    this.logout(); // Log out when user clicks back
  }
}
 
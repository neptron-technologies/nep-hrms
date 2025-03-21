import { Component, importProvidersFrom, HostListener } from '@angular/core';
import { LoginService } from '../../core/services/service-login.service';
import { Location } from '@angular/common';
import { RouterLink, RouterOutlet } from '@angular/router';
import { DataTransferService } from '../../core/services/data-transfer.service';

@Component({
  selector: 'app-dashboard',
  imports: [RouterOutlet, RouterLink],
  standalone: true,
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {
  constructor(private dataTransferService: LoginService, private location: Location,) { }

  logout(): void {
    this.dataTransferService.logout();
  }

  @HostListener('window:popstate', ['$event'])
  onPopState(event: Event): void {
    this.logout(); // Log out when user clicks back
  }
}

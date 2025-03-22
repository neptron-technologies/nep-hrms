import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { LoginService } from '../../services/service-login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  imports: [FormsModule, CommonModule],
  standalone: true
})
export class LoginComponent {
  username: string = '';
  password: string = '';
  errorMessage: string = '';

  constructor(
    private loginService: LoginService,
    private router: Router
  ) { }

  login(): void {
    if (!this.username || !this.password) {
      this.errorMessage = 'Please enter both ID and Password';
      return;
    }

    this.loginService.login(this.username, this.password).subscribe({
      next: (response) => {
        console.log('API Response:', response);

        if (response.token) {
          this.router.navigate(['/dashboard']).then(() =>{
            window.location.reload();
          });
        } else {
          this.errorMessage = 'User data is missing in API response';
        }
      },
      error: (err) => {
        this.errorMessage = err.error?.message || 'Invalid credentials';
      }
    });
  }
}

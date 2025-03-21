import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
interface LoginResponse {
  token: string;
  empId: number;
}
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  imports: [FormsModule],
  standalone: true
})

export class LoginComponent {
  username: string = '';
  password: string = '';
  errorMessage: string = '';

  constructor(
    private http: HttpClient,
    private router: Router
  ) { }

  login(): void {
    if (!this.username || !this.password) {
      this.errorMessage = 'Please enter both ID and Password';
      return;
    }

    const loginData = { username: this.username, password: this.password };
   
    this.http.post<LoginResponse>('https://localhost:44362/api/Login/Login', loginData).subscribe({
     
      next: (response) => {
  
        localStorage.setItem('token', response.token);
        localStorage.setItem('empId', response.empId.toString());
        this.router.navigate(['/dashboard']);
      },
      error: (err) => {
        this.errorMessage = err.error?.message || 'Login failed';
      }
    });
  }
}

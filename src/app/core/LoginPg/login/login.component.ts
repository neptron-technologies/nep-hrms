import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../../services/service-login.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  imports: [FormsModule],
})

export class LoginComponent {
  username = '';
  password = '';

  constructor(private authService: LoginService, private router: Router) {}

  login(): void {
    if (this.authService.login(this.username, this.password)) {
      this.router.navigate(['/dashboard']);
    } else {
      alert('Invalid Credentials');
    }
  }
}

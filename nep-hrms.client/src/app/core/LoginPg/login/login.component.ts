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





// import { Component } from '@angular/core';
// import { Router } from '@angular/router';
// import { FormsModule } from '@angular/forms';
// import { HttpClient } from '@angular/common/http';
// import { CommonModule } from '@angular/common';
// import { DataTransferService } from '../../services/data-transfer.service';

// @Component({
//   selector: 'app-login',
//   templateUrl: './login.component.html',
//   styleUrls: ['./login.component.css'],
//   imports: [FormsModule, CommonModule],
//   standalone: true
// })
// export class LoginComponent {
//   username: string = '';
//   password: string = '';
//   errorMessage: string = '';

//   constructor(
//     private http: HttpClient,
//     private router: Router,
//     private dataTransferService: DataTransferService,
//   ) { }

//   login(): void {
//     if (!this.username || !this.password) {
//       this.errorMessage = 'Please enter both ID and Password';
//       return;
//     }

//     const loginData = { username: this.username, password: this.password };
    
//     this.http.post<{ token: string, user: any }>('https://localhost:44362/api/Login/Login', loginData).subscribe({
//       next: (response) => {
//         console.log(response);
//         this.dataTransferService.saveToken(response.token); // Save token using AuthService
//         this.dataTransferService.saveUserData(response.user); // Save user data using AuthService
//         this.router.navigate(['/dashboard']);
//       },
//       error: (err) => {
//         this.errorMessage = err.error?.message || 'Invalid credentials';
//       }
//     });
//   }
// }


// import { Component } from '@angular/core';
// import { Router } from '@angular/router';
// import { FormsModule } from '@angular/forms';
// import { HttpClient } from '@angular/common/http';
// import { CommonModule } from '@angular/common';
// import { LoginService } from '../../services/service-login.service';
// import { DataTransferService } from '../../services/data-transfer.service';

// @Component({
//   selector: 'app-login',
//   templateUrl: './login.component.html',
//   styleUrls: ['./login.component.css'],
//   imports: [FormsModule, CommonModule],
//   standalone: true
// })
// export class LoginComponent {
//   username: string = '';
//   password: string = '';
//   errorMessage: string = '';

//   constructor(
//     private http: HttpClient,
//     private router: Router,
//     private dataTransferService: DataTransferService
//   ) { }

  
//   login(): void {
//     if (!this.username || !this.password) {
//       this.errorMessage = 'Please enter both ID and Password';
//       return;
//     }
  
//     const loginData = { username: this.username, password: this.password };
  
//     this.http.post<{ token: string; user: any }>('https://localhost:44362/api/Login/Login', loginData).subscribe({
//       next: (response) => {
//         console.log('API Response:', response);
  
//         if (response.token && response.user) {
//           localStorage.setItem('token', response.token);
//           this.dataTransferService.saveUserData(response.user); 
  
//           this.router.navigate(['/dashboard']);
//         } else {
//           console.warn('User data missing in API response'); 
//         }
//       },
//       error: (err) => {
//         this.errorMessage = err.error?.message || 'Invalid credentials';
//       }
//     });
//   }
// }

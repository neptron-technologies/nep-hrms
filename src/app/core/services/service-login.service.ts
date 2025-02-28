import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private user = {
    username: 'admin',
    password: 'password123',
    token: '' // Store Token in Local Storage for Authentication

  }
  constructor(private router: Router) {}

  login(username: string, password: string): Observable<boolean> {
    if(username === this.user.username && password === this.user.password){
      localStorage.setItem('token', this.user.token);
      return of(true);
    }
    return of(false);
  }

  // login(username: string, password: string): boolean {
  //   if (username === 'admin' && password === 'password123') {
  //     localStorage.setItem('token', 'mock-jwt-token'); // Store Token
  //     return true;
  //   }
  //   return false;
  // }

  logout(): void {
    localStorage.removeItem('token');
    this.router.navigate(['/']);
  }

  isLoggedIn(): boolean {
    return localStorage.getItem('token') !== null;
  }
}


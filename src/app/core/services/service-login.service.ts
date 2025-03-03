import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';


@Injectable({
  providedIn: 'root'
})
export class LoginService {
  constructor(private router: Router, private http: HttpClient) {}
 
  login(username: string, password: string): boolean {
    if (username === 'admin' && password === 'password123') {
      localStorage.setItem('token', 'mock-jwt-token'); // Store Token
      return true;
    }
    return false;
  }

  logout(): void {
    localStorage.removeItem('token');
    this.router.navigate(['/']);
  }

  isLoggedIn(): boolean {
    return localStorage.getItem('token') !== null;
  }
}


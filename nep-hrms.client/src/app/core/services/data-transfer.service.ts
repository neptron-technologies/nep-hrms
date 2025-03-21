import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DataTransferService {

  constructor() { }

  saveUserData(user: any): void {
    if (user) {
      console.log('Saving User Data:', user);
      localStorage.setItem('user', JSON.stringify(user));
    } else {
      console.warn('Attempted to save undefined user data');
    }
  }
  
  // getEmpId(): number | null {
  //   const user = localStorage.getItem('user');
  //   return user ? JSON.parse(user).empId : null;
  // }
  getEmpId(): number | null {
    const user = localStorage.getItem('user');
    const empId = user ? JSON.parse(user).empId : null;
    console.log('Retrieved empId:', empId); 
    return empId;
  }

  saveToken(token: string): void {
    localStorage.setItem('token', token);
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  isLoggedIn(): boolean {
    return !!this.getToken();
  }

  logout(): void {
    localStorage.removeItem('user');
    localStorage.removeItem('token');
  }
}

import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DataTransferService {

  constructor() { }

  saveUserData(user: any): void {
    if (user) {
      console.log('Saving User Data:', user); // Debug log
      if (!user.empId) {
        console.warn('Warning: empId is missing from user data');
      }
      localStorage.setItem('user', JSON.stringify(user)); // Store user in localStorage
    } else {
      console.warn('Attempted to save undefined user data');
    }
  }
  
  getEmpId(): number | null {
    const user = localStorage.getItem('user');
    //console.log('Raw User Data from LocalStorage:', user);
    const empId = user ? JSON.parse(user).empId : null;
    //console.log('Retrieved empId:', empId);
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


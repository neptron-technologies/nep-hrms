import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { DataTransferService } from './data-transfer.service';
import { Observable, tap } from 'rxjs';
 
@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private apiUrl = 'https://localhost:44362/api/Login/Login';
  constructor(
    private router: Router,
    private http: HttpClient,
    private dataTransferService: DataTransferService
  ) { }
 
  login(username: string, password: string): Observable<any> {
    const loginData = { username, password };
    return this.http.post<{ empId: number; username: string; roles: any[]; permissions: any[]; token: string }>(this.apiUrl, loginData).pipe(
 
     
      tap(responce => {
        if (responce.token){
          console.log(responce.token);
          debugger;
          this.dataTransferService.saveToken(responce.token);
          const user = {
            empId: responce.empId,
            username: responce.username,
            roles: responce.roles,
            permissions: responce.permissions
          };
         
          if (user.empId) {
            debugger;
            console.log('Extracted User Data:', user);
            this.dataTransferService.saveUserData(user);
          } else {
            console.error('Error: User data is missing in API response');
          }
        }
      })
    );
  }
  logout(): void {
    this.dataTransferService.logout();
    this.router.navigate(['/login']);
  }
 
  isLoggedIn(): boolean {
    return this.dataTransferService.isLoggedIn();
  }
}
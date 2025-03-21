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

    return this.http.post<{ token: string; user: any}>(this.apiUrl, loginData).pipe(
      tap(responce => {
        if (responce.token){
          this.dataTransferService.saveToken(responce.token);
          if(responce.user){
            this.dataTransferService.saveUserData(responce.user);
          }else{
            console.log('User data is missing in API response');
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
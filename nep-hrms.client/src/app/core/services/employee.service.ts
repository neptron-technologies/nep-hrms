import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private apiUrl = 'http://localhost:3000/employees';
  constructor(private http: HttpClient) { }

  addEmployee(employee: any): Observable<any> {
    return this.http.post(this.apiUrl, employee);
  }
}

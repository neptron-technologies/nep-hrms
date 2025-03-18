import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from '../Models/Employee';
import { Attendance } from '../Models/Attendance';

@Injectable({
  providedIn: 'root'
})
export class SuperAdminService {
  private baseUrl = 'https://localhost:44362/api/Employee';


  constructor(private http: HttpClient) { }

  getEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(`${this.baseUrl}/GetEmployees`);
  }

  //   getAttendance(emp_id: number): Observable<Attendance> {
  //     return this.http.get<Attendance>(`https://localhost:44362/api/controller/${emp_id}`);
  // }

  getAttendanceSummary(empId: number) {
    return this.http.get(`https://localhost:44362/api/controller/summary/${empId}`);
  }

}

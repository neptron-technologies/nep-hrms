import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Attendance } from '../Models/Attendance';
@Injectable({
  providedIn: 'root'
})
export class AttendanceService {
  private baseUrl = 'http://localhost:3001/getproject';
  constructor(private http: HttpClient) {
  }
  addAttendance(obj: Attendance): Observable<Attendance> {
    return this.http.post<Attendance>("", obj);
  }

  updateAttendance(id: number, obj: Attendance): Observable<Attendance> {
    return this.http.put<Attendance>("" + id, obj);
  }

  getAttendanceStatus(apiUrl: string, employeeId: number): Observable<Attendance> {
    return this.http.get<Attendance>(`${apiUrl}/${employeeId}`);
  }

  getEmployeeProjectId(emp_id: number): Observable<any> {
    //return this.http.get(`${this.baseUrl}=${emp_id}`);
     return this.http.get<Attendance>("http://localhost:3001/getproject?=2" );
  }
  
  // Method to delete an employee

  // deleteAttendance(attendaceid: string): Observable<any> {
  //   return this.http.delete<any>(`${this.apiUrl}/${attendaceid}`);
  // }
}

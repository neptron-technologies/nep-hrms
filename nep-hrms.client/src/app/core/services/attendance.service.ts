import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Attendance } from '../Models/Attendance';
@Injectable({
  providedIn: 'root'
})
export class AttendanceService {

  constructor(private http: HttpClient) {
  }
  addAttendance(obj: Attendance): Observable<Attendance> {
    return this.http.post<Attendance>("", obj);
  }

  updateAttendance(id: number, obj: Attendance): Observable<Attendance> {
    return this.http.put<Attendance>("" + id, obj);
  }

  // Method to delete an employee
  // deleteAttendance(attendaceid: string): Observable<any> {
  //   return this.http.delete<any>(`${this.apiUrl}/${attendaceid}`);
  // }
}

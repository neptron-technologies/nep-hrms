import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AttendanceInfo } from '../Models/AttendanceInfo';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmpdashboardService {

  constructor(private http: HttpClient) { }




  // getPayslip(empId: number): Observable<any> {
  //   return this.http.get<any>(`${this.apiUrl}${empId}`);
  getAttndanceInfo(empId: number):Observable<AttendanceInfo[]> {
      console.log(empId);
        return this.http.get<AttendanceInfo[]>('https://localhost:44362/api/controller/attendanceInfo/' + empId);
  }
}

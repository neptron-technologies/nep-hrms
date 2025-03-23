// import { HttpClient, HttpParams } from '@angular/common/http';
// import { Injectable } from '@angular/core';
// import { Observable } from 'rxjs';
// import { Attendance } from '../Models/Attendance';
// import { DatePipe } from '@angular/common';
 
// @Injectable({
//   providedIn: 'root'
// })
// export class AttendanceService {
//   private apiUrl = 'https://localhost:44362/api/attendance/GetAttendanceByDateRange/';
 
//   constructor(private http: HttpClient, private datePipe: DatePipe) {
//   }
 
//   getAttendanceById(empId: number, startDt: Date, endDt: Date): Observable<Attendance[]> {
 
//     let startDate = this.datePipe.transform(startDt, 'yyyy/MM/dd');
//     let endDate = this.datePipe.transform(endDt, 'yyyy/MM/dd');
 
//     const params = new HttpParams()
//       .set('empId', empId)
//       .set('startDate', startDate != null ? startDate : '')
//       .set('endDate', endDate != null ? endDate : '');
 
//     return this.http.get<Attendance[]>(`${this.apiUrl}`, {params});
//   }
//   addAttendance(attendance: Attendance[]): Observable<{ success: boolean; message: string }> {  
//     return this.http.post<{ success: boolean; message: string }>(
//         'https://localhost:44362/api/Attendance/AddAttendance', attendance
//     );
// }
 
//   updateAttendance(id: number, obj: Attendance): Observable<Attendance> {
//     return this.http.put<Attendance>("" + id, obj);
//   }
//   getEmployeeProjectId(emp_id: number): Observable<any> {
//     //return this.http.get(`${this.baseUrl}=${emp_id}`);
//     return this.http.get<Attendance>("https://localhost:44362/api/projects/GetProjectsByEmpId/"+emp_id);
//   }
// }
 
 
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Attendance } from '../Models/Attendance';
import { DatePipe } from '@angular/common';
 
@Injectable({
  providedIn: 'root'
})
export class AttendanceService {
  private apiUrl = 'https://localhost:44362/api/attendance/GetAttendanceByDateRange/';
 
  constructor(private http: HttpClient, private datePipe: DatePipe) {
  }
 
  getAttendanceById(empId: number, startDt: Date, endDt: Date): Observable<Attendance[]> {
 
    let startDate = this.datePipe.transform(startDt, 'yyyy/MM/dd');
    let endDate = this.datePipe.transform(endDt, 'yyyy/MM/dd');
 
    const params = new HttpParams()
      .set('empId', empId)
      .set('startDate', startDate != null ? startDate : '')
      .set('endDate', endDate != null ? endDate : '');
 
    return this.http.get<Attendance[]>(`${this.apiUrl}`, {params});
  }
  addAttendance(attendance: Attendance[]): Observable<{ success: boolean; message: string }> {  
    return this.http.post<{ success: boolean; message: string }>(
        'https://localhost:44362/api/Attendance/AddAttendance', attendance
    );
}
 
  updateAttendance(id: number, obj: Attendance): Observable<Attendance> {
    return this.http.put<Attendance>("" + id, obj);
  }
  getEmployeeProjectId(emp_id: number): Observable<any> {
    //return this.http.get(`${this.baseUrl}=${emp_id}`);
    return this.http.get<Attendance>("http://localhost:3001/getproject" );
  }
}
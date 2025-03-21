import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AttendanceInfo } from '../Models/AttendanceInfo';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmpdashboardService {

  constructor(private http: HttpClient) { }




  getAttndanceInfo(id:number):Observable<AttendanceInfo[]> {
    
        return this.http.get<AttendanceInfo[]>("https://localhost:44362/api/controller/attendanceInfo/" + id);
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Applyleave } from '../Models/ApplyLeave';

@Injectable({
  providedIn: 'root'
})
export class ApplyleaveService {

  constructor(private http: HttpClient) { }

  
  applyLeave(leaveData: Applyleave): Observable<Applyleave[]> {
    console.log(leaveData);
    return this.http.post<any>('https://localhost:44362/api/controller/ApplyLeave',leaveData)
    }

  getHoliday(): Observable<any> {
    return this.http.get<any>("https://localhost:44362/api/controller/GetHolidays");
    //return this.http.get<Employee[]>(this.apiUrl)
  }
  getLeave(id: number): Observable<Applyleave[]> {

    return this.http.get<Applyleave[]>("https://localhost:44362/api/controller?EmpId=" + id);
  }
  cancelLeave(id: number): Observable<Applyleave> {
    return this.http.get<Applyleave>("https://localhost:44362/api/controller/CancelLeave?leaveId=" + id);
  }

}

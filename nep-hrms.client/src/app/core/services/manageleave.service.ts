import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Applyleave } from '../Models/ApplyLeave';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ManageleaveService {


  constructor(private http: HttpClient) { }


  getPendingLeave(): Observable<Applyleave[]> {

    return this.http.get<Applyleave[]>("https://localhost:44362/api/controller/GetPendingLeave");

  }

  approveLeave(id: number): Observable<Applyleave> {
    return this.http.get<Applyleave>("https://localhost:44362/api/controller/ApproveLeave?id=" + id);
  }

  rejectLeave(id: number): Observable<Applyleave> {
    return this.http.get<Applyleave>("https://localhost:44362/api/controller/RejectLeave?id=" + id);
  }


}

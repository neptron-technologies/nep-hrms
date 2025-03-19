import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class PayslipService {
  private apiUrl = 'YOUR_API_ENDPOINT_HERE';
  constructor(private http: HttpClient) { }
  getPayslip(employeeId: string): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/payslip/${employeeId}`);
  }
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class PayslipService {
  private apiUrl = 'https://localhost:44362/api/Payslip/GetPayslipByEmpId?EmpId=';
  constructor(private http: HttpClient) { }
  
  getPayslip(empId: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}${empId}`);

    //return this.http.get<any>(`${this.apiUrl}/${employeeId}`);
  }
}

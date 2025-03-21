import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Payslip } from '../Models/Payslip';

@Injectable({
  providedIn: 'root'
})
export class PayslipService {
  private apiUrl = 'https://localhost:44362/GetBankDetailsById';

  constructor(private http: HttpClient) { }

  getPayslip(empId: number): Observable<Payslip> {
    return this.http.get<Payslip>(`${this.apiUrl}?empId=${empId}`);
  }
}

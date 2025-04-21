import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpHeaders } from '@angular/common/http'
import { Employee } from '../Models/Employee';

@Injectable({
  providedIn: 'root',

})
export class EmpService {
  private apiUrl= "https://localhost:44362/api/Employee/GetEmployees"; //added

  constructor(private http: HttpClient) { }


  addEmployee(obj: Employee): Observable<Employee> {
    return this.http.post<Employee>("https://localhost:44362/api/Employee/AddEmployee", obj);
  }

  updateEmployee(id: number, obj: Employee) {
    return this.http.put<Employee>("https://localhost:44362/api/Employee/UpdateEmployee?=" + id, obj);
  }

  // Method to delete an employee
  deleteEmployee(id: number) {
    return this.http.delete<Employee>("https://localhost:44362/api/Employee/DeleteEmployee?id=" + id);
  }

  getEmployees(): Observable<Employee[]>{
    //return this.http.get<Employee[]>("https://localhost:44362/api/Employee/GetEmployees");
    return this.http.get<Employee[]>(this.apiUrl)
  }
  getEmpCode():Observable<any>{
    
    return this.http.get<any>("https://localhost:44362/api/Employee/GenerateEmpCode");
  }
}













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
    return this.http.post<Employee>("http://localhost:3001/addmethod", obj);
  }

  updateEmployee(id: number, obj: Employee) {
    return this.http.put<Employee>("http://localhost:3001/updatemethod?=" + id, obj);
  }

  // Method to delete an employee
  deleteEmployee(id: number) {
    return this.http.delete<Employee>("http://localhost:3001/deletemethod?=" + id);
  }

  getEmployees(): Observable<Employee[]>{
    //return this.http.get<Employee[]>("https://localhost:44362/api/Employee/GetEmployees");
    return this.http.get<Employee[]>(this.apiUrl)
  }
}













import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Project {
  id?: number;
  projectName: string;
  description?: string;
  startDate: string;
  endDate?: string | null;
  createdBy: string;
  status: string;
  empId: number;
  fname: string;
}

@Injectable({
  providedIn: 'root'
})
export class ProjectManagerService {
  private baseUrl = 'https://localhost:44362/api/projects';

  constructor(private http: HttpClient) {}

  getEmployeesByProject(projectId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/GetEmployeesByProject/${projectId}`);
  }

  getProjectsByEmployee(employeeId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/GetProjectsByEmpId/${employeeId}`);
  }

  addEmployeeToProject(projectId: number, employeeId: number): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/AddEmployeeToProject/${projectId}/${employeeId}`, {});
  }

   getProjects(): Observable<Project[]> {
    return this.http.get<Project[]>(`${this.baseUrl}/GetAllProjects`);
  }

addProject(project: Project): Observable<Project> {
  const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
  return this.http.post<Project>(`${this.baseUrl}/AddProjects`, project, { headers });
}

updateProject(projectId: number, project: Project): Observable<Project> {
  const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
  return this.http.put<Project>(`${this.baseUrl}/Update/${projectId}`, JSON.stringify(project), { headers });
}

deleteProject(projectId: number): Observable<void> {
  return this.http.delete<void>(`${this.baseUrl}/${projectId}`);
}
}
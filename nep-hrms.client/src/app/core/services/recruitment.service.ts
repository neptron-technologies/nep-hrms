import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RecruitmentService {
  private apiUrl = "https://localhost:44362/api/Recruitment";

  constructor(private http: HttpClient) { }

  getRecruitments(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/ListofCandidates`);
  }

  addRecruitment(data: any): Observable<any> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<any>(`${this.apiUrl}/AddCandidates`, JSON.stringify(data), { headers });
  }  

  updateRecruitment(id: number, data: any): Observable<any> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.put<any>(`${this.apiUrl}/UpdateCandidate/${id}`, JSON.stringify(data), { headers });
  }  

  deleteRecruitment(id: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/DeleteCandidateBy/${id}`);
  }
}


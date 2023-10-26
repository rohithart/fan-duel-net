import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Player } from 'src/app/models/Player';
import { environment } from 'src/environments/environment';
import { TeamDepth } from '../models/TeamDepth';

@Injectable({
  providedIn: 'root'
})
export class DepthService {
  private baseUrl: string = `${environment.api_url}/teamdepth`;

  constructor(private http: HttpClient) {}

  getTeamDepth(teamId: string): Observable<TeamDepth> {
    return this.http.get<TeamDepth>(`${this.baseUrl}/${teamId}`);
  }

  addPlayerToDepthChart(id: string, data: any): Observable<TeamDepth> {
    return this.http.post<TeamDepth>(`${this.baseUrl}/${id}/add-player`, data);
  }

  removePlayerToDepthChart(id: string, data: any): Observable<TeamDepth> {
    return this.http.put<TeamDepth>(`${this.baseUrl}/${id}/remove-player`, data);
  }

  getBackups(id: string, data: any): Observable<Player[]> {
    return this.http.post<Player[]>(`${this.baseUrl}/${id}/backups`, data);
  }
}

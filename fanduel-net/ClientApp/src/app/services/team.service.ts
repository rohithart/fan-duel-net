import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Team } from 'src/app/models/Team';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TeamService {
  private baseUrl: string = `${environment.api_url}/teams`;

  constructor(private http: HttpClient) {}

  getAllTeams(): Observable<Team[]> {
    return this.http.get<Team[]>(this.baseUrl);
  }

  getAllTeamsFor(sportId: string): Observable<Team[]> {
    return this.http.get<Team[]>(`${this.baseUrl}/sports/${sportId}`);
  }

  getTeam(teamId: string): Observable<Team> {
    return this.http.get<Team>(`${this.baseUrl}/${teamId}`)
  }
}

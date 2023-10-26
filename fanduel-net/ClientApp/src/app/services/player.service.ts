import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Player } from 'src/app/models/Player';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PlayerService {
  private baseUrl: string = `${environment.api_url}/players`;

  constructor(private http: HttpClient) {}

  getAllPlayers(teamId: string): Observable<Player[]> {
    return this.http.get<Player[]>(`${this.baseUrl}/team/${teamId}`);
  }

  addPlayer(player: Player): Observable<any> {
    return this.http.post(this.baseUrl, player);
  }
}

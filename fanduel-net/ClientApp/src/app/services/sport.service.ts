import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Sport } from 'src/app/models/Sport';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SportService {
  private baseUrl: string = `${environment.api_url}/sports`;

  constructor(private http: HttpClient) {}

  getAllSports(): Observable<Sport[]> {
    return this.http.get<Sport[]>(this.baseUrl);
  }

  getSport(sportId: string): Observable<Sport> {
    return this.http.get<Sport>(`${this.baseUrl}/${sportId}`);
  }
}

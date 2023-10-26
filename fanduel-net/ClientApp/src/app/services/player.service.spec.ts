import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { PlayerService } from './player.service';
import { Player } from 'src/app/models/Player';
import { Team } from '../models/Team';

describe('PlayerService', () => {
  let service: PlayerService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [PlayerService],
    });

    service = TestBed.inject(PlayerService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  describe('#getAllPlayers', () => {
    it('should call the backend API with the specified teamId and return players', () => {
      const teamId = '1';
      const mockPlayers: Player[] = [
        { id: '1', name: 'Player 1', num: 10, team: {} as Team },
        { id: '2', name: 'Player 2', num: 12, team: {} as Team },
      ];

      service.getAllPlayers(teamId).subscribe((players) => {
        expect(players).toEqual(mockPlayers);
      });

      const req = httpMock.expectOne(`${service['baseUrl']}/team/${teamId}`);
      expect(req.request.method).toBe('GET');
      req.flush(mockPlayers);

      httpMock.verify();
    });
  });

  describe('#addPlayer', () => {
    it('should call the backend API with the provided player data and return a response', () => {
      const mockPlayer: Player = { id: '3', name: 'Player 3', num: 13, team: {} as Team };

      service.addPlayer(mockPlayer).subscribe((response) => {
        expect(response).toBeTruthy();
      });

      const req = httpMock.expectOne(`${service['baseUrl']}`);
      expect(req.request.method).toBe('POST');
      req.flush({});

      httpMock.verify();
    });
  });
});

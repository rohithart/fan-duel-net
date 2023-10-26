import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { DepthService } from './depth.service';
import { TeamDepth } from 'src/app/models/TeamDepth';
import { Player } from 'src/app/models/Player';
import { Team } from '../models/Team';

describe('DepthService', () => {
  let service: DepthService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [DepthService],
    });

    service = TestBed.inject(DepthService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  describe('#getTeamDepth', () => {
    it('should call the backend API with the specified teamId and return a TeamDepth object', () => {
      const teamId = '1';
      const mockTeamDepth: TeamDepth = { id: '1', team: {} as Team, depthChart: {} };

      service.getTeamDepth(teamId).subscribe((teamDepth) => {
        expect(teamDepth).toEqual(mockTeamDepth);
      });

      const req = httpMock.expectOne(`${service['baseUrl']}/${teamId}`);
      expect(req.request.method).toBe('GET');
      req.flush(mockTeamDepth);

      httpMock.verify();
    });
  });

  describe('#addPlayerToDepthChart', () => {
    it('should call the backend API with the provided id and data, and return a TeamDepth object', () => {
      const id = '1';
      const mockData: any = {};
      const mockTeamDepth: TeamDepth = { id: '1', team: {} as Team, depthChart: {} };

      service.addPlayerToDepthChart(id, mockData).subscribe((teamDepth) => {
        expect(teamDepth).toEqual(mockTeamDepth);
      });

      const req = httpMock.expectOne(`${service['baseUrl']}/${id}/add-player`);
      expect(req.request.method).toBe('POST');
      req.flush(mockTeamDepth);

      httpMock.verify();
    });
  });

  describe('#removePlayerToDepthChart', () => {
    it('should call the backend API with the provided id and data, and return a TeamDepth object', () => {
      const id = '1';
      const mockData: any = {};
      const mockTeamDepth: TeamDepth = { id: '1', team: {} as Team, depthChart: {} };

      service.removePlayerToDepthChart(id, mockData).subscribe((teamDepth) => {
        expect(teamDepth).toEqual(mockTeamDepth);
      });

      const req = httpMock.expectOne(`${service['baseUrl']}/${id}/remove-player`);
      expect(req.request.method).toBe('PUT');
      req.flush(mockTeamDepth);

      httpMock.verify();
    });
  });

  describe('#getBackups', () => {
    it('should call the backend API with the provided id and data, and return a list of Player objects', () => {
      const id = '1';
      const mockData: any = {};
      const mockPlayers: Player[] = [
        { id: '1', name:'player1', num: 10, team: {} as Team },
        { id: '2', name:'player2', num: 11, team: {} as Team },
      ];

      service.getBackups(id, mockData).subscribe((players) => {
        expect(players).toEqual(mockPlayers);
      });

      const req = httpMock.expectOne(`${service['baseUrl']}/${id}/backups`);
      expect(req.request.method).toBe('POST');
      req.flush(mockPlayers);

      httpMock.verify();
    });
  });
});

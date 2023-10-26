import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

import { TeamService } from './team.service';
import { Team } from 'src/app/models/Team';

describe('TeamService', () => {
  let service: TeamService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [TeamService],
    });

    service = TestBed.inject(TeamService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  describe('#getAllTeams', () => {
    it('should call the backend API and return teams', () => {
      const mockTeams: Team[] = [
        { id: '1', name: 'Team 1', sport: { id: '1', name: 'Sport-1' } },
        { id: '2', name: 'Team 2', sport: { id: '2', name: 'Sport-2' } },
      ];

      service.getAllTeams().subscribe((teams) => {
        expect(teams).toEqual(mockTeams);
      });

      const req = httpMock.expectOne(`${service['baseUrl']}`);
      expect(req.request.method).toBe('GET');
      req.flush(mockTeams);

      httpMock.verify();
    });
  });

  describe('#getAllTeamsFor', () => {
    it('should call the backend API with the specified sportId and return teams', () => {
      const sportId = '1';
      const mockTeams: Team[] = [
        { id: '1', name: 'Team 1', sport: { id: '1', name: 'Sport-1' } },
      ];

      service.getAllTeamsFor(sportId).subscribe((teams) => {
        expect(teams).toEqual(mockTeams);
      });

      const req = httpMock.expectOne(`${service['baseUrl']}/sports/${sportId}`);
      expect(req.request.method).toBe('GET');
      req.flush(mockTeams);

      httpMock.verify();
    });
  });

  describe('#getTeam', () => {
    it('should call the backend API with the specified teamId and return a team', () => {
      const teamId = '1';
      const mockTeam: Team = { id: '1', name: 'Team 1', sport: { id: '1', name: 'Sport-1' } };

      service.getTeam(teamId).subscribe((team) => {
        expect(team).toEqual(mockTeam);
      });

      const req = httpMock.expectOne(`${service['baseUrl']}/${teamId}`);
      expect(req.request.method).toBe('GET');
      req.flush(mockTeam);

      httpMock.verify();
    });
  });
});

import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { SportService } from './sport.service';
import { Sport } from 'src/app/models/Sport';

describe('SportService', () => {
  let service: SportService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [SportService],
    });

    service = TestBed.inject(SportService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  describe('#getAllSports', () => {
    it('should call the backend API and return sports', () => {
      const mockSports: Sport[] = [
        { id: '1', name: 'Sport 1' },
        { id: '2', name: 'Sport 2' },
      ];

      service.getAllSports().subscribe((sports) => {
        expect(sports).toEqual(mockSports);
      });

      const req = httpMock.expectOne(`${service['baseUrl']}`);
      expect(req.request.method).toBe('GET');
      req.flush(mockSports);

      httpMock.verify();
    });
  });

  describe('#getSport', () => {
    it('should call the backend API with the specified sportId and return a sport', () => {
      const sportId = '1';
      const mockSport: Sport = { id: '1', name: 'Sport 1' };

      service.getSport(sportId).subscribe((sport) => {
        expect(sport).toEqual(mockSport);
      });

      const req = httpMock.expectOne(`${service['baseUrl']}/${sportId}`);
      expect(req.request.method).toBe('GET');
      req.flush(mockSport);

      httpMock.verify();
    });
  });
});

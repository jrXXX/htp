import {
  HttpClientTestingModule,
  HttpTestingController,
} from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import FacilityService from './facility.service';

describe('FacilityService', () => {
  let service: FacilityService;
  let httpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [FacilityService],
    });
    service = TestBed.inject(FacilityService);
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  describe('getFacilities', () => {
    let FACILITIES = [
      { id: 1, name: 'Terrace' },
      { id: 2, name: 'Lobby' },
      { id: 3, name: 'Bellevue Bar' },
    ];

    it('schould make the call with the rigth url and the response length should be 4', () => {
      service.facilities.subscribe((response) => {
        expect(response.length).toBe(3);
        expect(response).toBe(FACILITIES);
      });

      //test the correct url
      const req = httpTestingController.expectOne('/api/getFacilities');
      expect(req.request.method).toBe('GET');
      req.flush(FACILITIES);
      httpTestingController.verify();
    });

    it('should get an error with status 404 when the server is not reachatable', () => {
      let err: string;
      service.facilities.subscribe(
        () => {},
        (error) => {
          err = error;
        }
      );

      const req = httpTestingController.expectOne('/api/getFacilities');
      expect(req.request.method).toBe('GET');
      req.flush('somethings went wrong', {
        status: 404,
        statusText: 'Network Error',
      });

      expect(err).toBeTruthy();
      httpTestingController.verify();
    });
  });
});

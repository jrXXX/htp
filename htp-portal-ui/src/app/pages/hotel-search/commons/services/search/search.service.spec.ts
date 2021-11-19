import {
  HttpClientTestingModule,
  HttpTestingController,
} from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import SearchService from './search.service';

describe('SearchService', () => {
  let service: SearchService;
  let httpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [SearchService],
    });
    service = TestBed.inject(SearchService);
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  describe('Post SearchService ', () => {
    const requestBody = {
      destinationCountry: 'Switzerland',
      destinationPostalCode: '8004',
      destinationCity: 'Bern',
      hotelName: 'Bellevue Palace',
      priceFrom: 0,
      priceTo: 0,
      currency: 'CHF',
      dateFrom: '2021-09-03',
      dateTo: '2021-09-06',
      numberOfGuests: '1',
    };
    it('should make the call with the rigth url and should the response length should be equal the mockresponse', () => {
      // arrange POST parameter

      // is that the righ url
      service.getSearchResults(JSON.stringify(requestBody)).subscribe();

      const req = httpTestingController.expectOne('/api/hotelSearch');
      expect(req.request.method).toBe('POST');
      expect(req.request.body).toEqual(requestBody);
      httpTestingController.verify();
    });

    it('should have a error when when the post request has been made', () => {
      let err = {};
      service.getSearchResults(JSON.stringify(requestBody)).subscribe(
        () => {},
        (error) => (err = error)
      );

      const req = httpTestingController.expectOne('/api/hotelSearch');
      expect(req.request.method).toBe('POST');
      req.flush('somethings went wrong', {
        status: 404,
        statusText: 'Network Error',
      });
      expect(err).toBeTruthy();
    });
  });
});

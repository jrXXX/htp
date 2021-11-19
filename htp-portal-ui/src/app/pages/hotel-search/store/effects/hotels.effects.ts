import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { catchError, concatMap, map, tap } from 'rxjs/operators';
import FacilityService from '../../commons/services/facility/facility.service';
import SearchService from '../../commons/services/search/search.service';
import {
  fecthedHotelFailed,
  fetchedFacilityFailed,
  fetchedFacilitySuccess,
  fetchedHotelSuccess,
  fetchFacility,
  fetchHotel,
} from '../actions/hotel-actions';

@Injectable()
export class HotelEffect {
  constructor(
    private actions$: Actions,
    private searchService: SearchService,
    private facilityService: FacilityService,
    private router: Router
  ) {}

  fetchHotel$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fetchHotel),
      concatMap(({ searchRequest }) => {
        return this.searchService.getSearchResults(searchRequest).pipe(
          map((searchResponse) => fetchedHotelSuccess({ searchResponse })),
          catchError((error) => {
            tap(() => this.router.navigateByUrl('/error'));
            return of(fecthedHotelFailed(error));
          })
        );
      })
    )
  );

  fetchFacility$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fetchFacility),
      concatMap(() => {
        return this.facilityService.facilities.pipe(
          map((response) => fetchedFacilitySuccess({ facilities: response })),
          catchError((error) => {
            return of(fetchedFacilityFailed(error));
          })
        );
      })
    )
  );
}

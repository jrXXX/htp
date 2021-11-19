import { createAction, props } from '@ngrx/store';
import { Facility } from 'src/app/api';
import { SearchResponse } from 'src/app/api';

export const fetchHotel = createAction(
  '[HotelSeacrhModule Hotel-Page-Search] fetch Hotel',
  props<{ searchRequest: string }>()
);

export const fetchedHotelSuccess = createAction(
  '[HotelSearchModule API SearchService] fetched Hotel Success',
  props<{ searchResponse: SearchResponse[] }>()
);

export const fecthedHotelFailed = createAction(
  '[HotelSearchModule API SearchService] fetched Hotel Failed',
  props<{ error: string }>()
);

export const fetchFacility = createAction(
  '[HotelSeacrhModule Hotel-Page-Search] fetch Facility'
);

export const fetchedFacilitySuccess = createAction(
  '[HotelSearchModule API FacilityService] fetched Facility Success',
  props<{ facilities: Facility[] }>()
);

export const fetchedFacilityFailed = createAction(
  '[HotelSearchModule API FacilityService]  fetched Facility Failed',
  props<{ error: string }>()
);

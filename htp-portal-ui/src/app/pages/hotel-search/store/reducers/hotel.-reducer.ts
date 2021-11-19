import { Action, createReducer, on } from '@ngrx/store';
import { SearchResponse } from 'src/app/api';
import { Facility } from 'src/app/api';
import countryList from './countryList';
import {
  fecthedHotelFailed,
  fetchedFacilityFailed,
  fetchedFacilitySuccess,
  fetchedHotelSuccess,
  fetchHotel,
} from '../actions/hotel-actions';

export interface HotelState {
  data: SearchResponse[];
  countries: string[];
  isLoading: boolean;
  facilities: Facility[];
  error: string | null;
}

export const initialState: HotelState = {
  data: [],
  isLoading: false,
  error: '',
  facilities: [],
  countries: countryList,
};

const hotelReducer = createReducer(
  initialState,
  on(fetchHotel, (state, action) => {
    return {
      ...state,
      isLoading: true,
    };
  }),
  on(fetchedHotelSuccess, (state, { searchResponse }) => {
    return {
      ...state,
      isLoading: false,
      data: searchResponse,
    };
  }),
  on(fecthedHotelFailed, (state, { error }) => {
    return {
      ...state,
      isLoading: false,
      error: error,
    };
  }),
  on(fetchedFacilitySuccess, (state, { facilities }) => {
    return {
      ...state,
      facilities: facilities,
    };
  }),
  on(fetchedFacilityFailed, (state, { error }) => {
    return {
      ...state,
      error: error,
    };
  })
);

export function reducer(state: HotelState | undefined, action: Action) {
  return hotelReducer(state, action);
}

/****
 * get selected properties from states
 */
export const getHotelDataState = (state: HotelState) => state.data;

export const getLoadingState = (state: HotelState) => state.isLoading;

export const getErrorState = (state: HotelState) => state.error;

export const getFacilitiesState = (state: HotelState) => state.facilities;

export const getCountriesState = (state: HotelState) => state.countries;

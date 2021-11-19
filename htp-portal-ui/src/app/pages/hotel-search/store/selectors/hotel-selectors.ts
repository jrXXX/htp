import { createFeatureSelector, createSelector } from '@ngrx/store';
import * as fromHotelReducer from './../reducers/hotel.-reducer';

export const hotelFeatureSelector = createFeatureSelector('hotel');

export const getHotelDataSelector = createSelector(
  hotelFeatureSelector,
  fromHotelReducer.getHotelDataState
);

export const getIsLoadingSelector = createSelector(
  hotelFeatureSelector,
  fromHotelReducer.getLoadingState
);

export const getErrorSelector = createSelector(
  hotelFeatureSelector,
  fromHotelReducer.getErrorState
);

export const getFacilitiesSelector = createSelector(
  hotelFeatureSelector,
  fromHotelReducer.getFacilitiesState
);

export const getCountriesSelector = createSelector(
  hotelFeatureSelector,
  fromHotelReducer.getCountriesState
);

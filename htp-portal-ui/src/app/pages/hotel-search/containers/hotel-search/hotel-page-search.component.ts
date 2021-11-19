import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { filter } from 'rxjs/operators';
import { Facility, SearchRequest, SearchResponse } from 'src/app/api';
import { Observable } from 'rxjs';
import { AuthStoreService } from 'src/app/core/services/auth-store/auth-store.service';
import { select, Store } from '@ngrx/store';
import { fetchFacility, fetchHotel } from '../../store/actions/hotel-actions';
import {
  getCountriesSelector, 
  getFacilitiesSelector,
  getHotelDataSelector,
  getIsLoadingSelector,
} from '../../store/selectors/hotel-selectors';
import { selectQueryParams } from 'src/app/store/selectors/router.selector';
import { LoadingService } from 'src/app/core/services';

@Component({
  selector: 'app-hotel-search',
  templateUrl: './hotel-page-search.component.html',
  styleUrls: ['./hotel-page-search.component.scss'],
})
export class HotelPageSearchComponent implements OnInit {
  allFacilities$: Observable<Facility[]>;
  countryList$: Observable<string[]>;
  searchResponse$: Observable<SearchResponse[]>;
  isLogin = false;

  searchItem: SearchRequest = {};

  imageObject: Array<object> = [
    {
      image: 'https://picsum.photos/id/1000/600/600.jpg',
      thumbImage: 'https://picsum.photos/id/1000/200/200.jpg',
      alt: 'alt of image',
      title: 'title of image',
    },
    {
      image: 'https://picsum.photos/id/1010/600/600.jpg',
      thumbImage: 'https://picsum.photos/id/1010/200/200.jpg',
      alt: 'alt of image',
      title: 'title of image',
      order: 1, //Optional: if you pass this key then slider images will be arrange according @input: slideOrderType
    },
    {
      image: 'https://picsum.photos/id/1001/600/600.jpg',
      thumbImage: 'https://picsum.photos/id/1001/200/200.jpg',
      alt: 'alt of image',
      title: 'title of image',
      order: 1, //Optional: if you pass this key then slider images will be arrange according @input: slideOrderType
    },
  ];
 
  constructor(
    private authStoreService: AuthStoreService,
    private activatedRoute: ActivatedRoute,
    private loadingService: LoadingService,
    private store: Store
  ) {
    this.searchResponse$ = this.store.pipe(select(getHotelDataSelector));
  }

  ngOnInit(): void {
    this.store.dispatch(fetchFacility());
    this.countryList$ = this.store.pipe(select(getCountriesSelector));
    this.allFacilities$ = this.store.pipe(select(getFacilitiesSelector));
    this.store
      .pipe(select(selectQueryParams))
      .subscribe(
        ({
          destinationCountry,
          destinationCity,
          destinationPostalCode,
          hotelName,
          priceTo,
          priceFrom,
          dateFrom,
          dateTo,
        }) => {
          this.searchItem.destinationCountry = destinationCountry;
          this.searchItem.destinationCity = destinationCity;
          this.searchItem.destinationPostalCode = destinationPostalCode;
          this.searchItem.hotelName = hotelName;
          this.searchItem.priceTo = priceTo;
          this.searchItem.priceFrom = priceFrom;
          this.searchItem.dateFrom = dateFrom;
          this.searchItem.dateTo = dateTo;
        }
      );

      this.store.pipe(select(getIsLoadingSelector)).subscribe(
        (
          isLoading
        ) => {
          if (isLoading) {
            this.loadingService.showLoadingComponent();
          } else {
            this.loadingService.hideLoadingComponent();
          }
        }
      );

    this.authStoreService.isLoggin$
      .pipe(filter((log) => log))
      .subscribe((log) => (this.isLogin = log));
  }

  logInAndSearch = (event: FormGroup): void => {
    this.authStoreService.login().subscribe(
      () => {
        this.search(event);
      },
      (error) => {
        alert('login failed');
      }
    );
  };

  search = (event: FormGroup): void => {
    const searchContent = JSON.stringify(event.getRawValue());
    this.store.dispatch(fetchHotel({ searchRequest: searchContent })); 
  };

  getJsonDate(date: Date): string {
    if (!date) {
      return '';
    }
    return isNaN(date.getTime()) ? '' : date.toISOString().split('T')[0];
  }

  onSubmit(event: FormGroup): void {
    if (!this.isLogin) {
      this.logInAndSearch(event);
    } else {
      this.search(event);
    }
  }
}

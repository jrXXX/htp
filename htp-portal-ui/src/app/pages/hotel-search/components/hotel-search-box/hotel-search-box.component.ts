import {
  ChangeDetectionStrategy,
  Component,
  EventEmitter,
  Input,
  OnChanges,
  OnInit,
  Output,
  SimpleChanges,
} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Facility, SearchRequest } from 'src/app/api';
 
@Component({
  selector: 'akros-hotel-search-box',
  templateUrl: './hotel-search-box.component.html',
  styleUrls: ['./hotel-search-box.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class HotelSearchBoxComponent implements OnInit, OnChanges {
  searchForm: FormGroup;
  errorMessage = false;

  @Input()
  allFacilities: Facility[];

  @Input()
  countryList: string[];

  @Input()
  searchItem: SearchRequest;

  @Output()
  searchFormValue = new EventEmitter<FormGroup>();

  @Output()
  sharedUrlValue = new EventEmitter<string>();

  minDate: Date = new Date();

  constructor(private formBuilder: FormBuilder, private router: Router) {}

  ngOnChanges(changes: SimpleChanges): void {
    if (this.searchForm) {
      this.setSearchFormValues(this.searchItem);
    }
  }

  ngOnInit(): void {
    this.initForm();
  }

  setSearchFormValues(searchItem: SearchRequest): void {
    this.searchForm.patchValue(searchItem);
  }

  initForm() {
    if (this.searchForm) {
      null;
    }

    this.searchForm = this.formBuilder.group({
      destinationCountry: ['', Validators.required],
      destinationCity: ['', Validators.required],
      destinationPostalCode: [''],
      hotelName: [''],
      priceFrom: [''],
      priceTo: [''],
      currency: [{ value: 'CHF', disabled: true }],
      dateFrom: ['', Validators.required],
      dateTo: ['', Validators.required],
      durationDays: ['', [Validators.min(0), Validators.max(10)]],
      numberOfGuests: [1, Validators.min(1)],
      facilityList: this.formBuilder.control([]),
    });
  }

  checkDuration(): void {
    if (this.searchForm) {
      const dateFrom = this.searchForm.get('dateFrom').value;
      const dateTo = this.searchForm.get('dateTo').value;
      const diff = dateTo.getDate() - dateFrom.getDate();
      this.searchForm.get('durationDays').setValue(diff);
      if (diff > 10) {
        this.errorMessage = true;
      } else {
        this.errorMessage = false;
      }
    }
  }

  getShareUrl(): string {
    let shareUrl =
      location.protocol + '//' + location.host + this.router.url.split('?')[0];

    shareUrl = this.checkAndAddParameter(
      shareUrl,
      'destinationCountry',
      this.searchForm.get('destinationCountry').value,
      true
    );
    shareUrl = this.checkAndAddParameter(
      shareUrl,
      'destinationCity',
      this.searchForm.get('destinationCity').value
    );
    shareUrl = this.checkAndAddParameter(
      shareUrl,
      'destinationPostalCode',
      this.searchForm.get('destinationPostalCode').value
    );
    shareUrl = this.checkAndAddParameter(
      shareUrl,
      'hotelName',
      this.searchForm.get('hotelName').value
    );
    shareUrl = this.checkAndAddParameter(
      shareUrl,
      'priceFrom',
      this.searchForm.get('priceFrom').value
    );
    shareUrl = this.checkAndAddParameter(
      shareUrl,
      'priceTo',
      this.searchForm.get('priceTo').value
    );
    shareUrl = this.checkAndAddParameter(
      shareUrl,
      'currency',
      this.searchForm.get('currency').value
    );
    shareUrl = this.checkAndAddParameter(
      shareUrl,
      'dateFrom',
      this.getJsonDate(this.searchForm.get('dateFrom').value)
    );
    shareUrl = this.checkAndAddParameter(
      shareUrl,
      'dateTo',
      this.getJsonDate(this.searchForm.get('dateTo').value)
    );

    return shareUrl;
  }

  getJsonDate(dateString: string): string {
    if (!dateString) {
      return '';
    }
    
    const date = new Date(dateString);

    if(!date){
      return '';
    }

    // Reminder: getUTCMonth() return Index from 0..11 not the Number of month
    const monthString = date.getUTCMonth() < 10 ? `0${date.getUTCMonth()+1}`: date.getUTCMonth()+1;
    const dayString = date.getUTCDate() < 10 ? `0${date.getUTCDate()+1}`: date.getUTCDate()+1;

    return `${date.getUTCFullYear()}-${monthString}-${dayString}`
  }

  checkAndAddParameter(
    shareUrl: string,
    urlParameterName: string,
    urlParameterValue: Object,
    isFirstElement = false
  ): string {
    if (
      urlParameterValue === undefined ||
      urlParameterValue.toString().length == 0
    )
      return shareUrl;

    shareUrl += isFirstElement ? '?' : '&';
    shareUrl += urlParameterName + '=';
    shareUrl += encodeURIComponent(urlParameterValue.toString());

    return shareUrl;
  }

  onSubmit(): void {
    if (this.searchForm.valid) {
      this.searchFormValue.emit(this.searchForm);
      this.sharedUrlValue.emit(this.getShareUrl());
    }
  }
}

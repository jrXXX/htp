import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelSearchBoxComponent } from './hotel-search-box.component';

describe('HotelSearchBoxComponent', () => {
  let component: HotelSearchBoxComponent;
  let fixture: ComponentFixture<HotelSearchBoxComponent>;

  let mockAuthStoreService;
  let mockFacilityService;
  let mockSearchService;
  let mockloadingService;
  let mockCountryService;
  let mockRouter;

  beforeEach(async () => {
    mockAuthStoreService = jasmine.createSpyObj(['login']);
    mockSearchService = jasmine.createSpyObj(['getSearchResults']);
    mockloadingService = jasmine.createSpyObj([''])
    await TestBed.configureTestingModule({
      declarations: [HotelSearchBoxComponent],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HotelSearchBoxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  xit('should create', () => {
    expect(component).toBeTruthy();
  });
});

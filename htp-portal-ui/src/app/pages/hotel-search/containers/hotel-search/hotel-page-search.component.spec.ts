import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HotelPageSearchComponent } from './hotel-page-search.component';

describe('HotelPageSearchComponent', () => {
  let component: HotelPageSearchComponent;
  let fixture: ComponentFixture<HotelPageSearchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HotelPageSearchComponent],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HotelPageSearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  xit('should create', () => {
    expect(component).toBeTruthy();
  });
});

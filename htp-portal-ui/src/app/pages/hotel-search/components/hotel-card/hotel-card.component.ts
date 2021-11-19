import { Component, Input, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'akros-hotel-card',
  templateUrl: './hotel-card.component.html',
  styleUrls: ['./hotel-card.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class HotelCardComponent {
  @Input()
  bookingResponse: any;

  @Input()
  room: any;

  colsToDisplay: number;

  constructor() {}

  stars(stars: number): number[] {
    return Array.from(Array(stars));
  }

  onResize(event) {
    this.colsToDisplay = window.innerWidth <= 800 ? 1 : 3;
  }
}

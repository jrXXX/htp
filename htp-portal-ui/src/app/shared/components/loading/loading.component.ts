import { Component, OnInit } from '@angular/core';
import { LoadingService } from '../../../core/services/loading/loading.service';

@Component({
  selector: 'akros-loading',
  templateUrl: './loading.component.html',
  styleUrls: ['./loading.component.scss'],
})
export class LoadingComponent implements OnInit {
  constructor(public loadingService: LoadingService) {}

  ngOnInit(): void {}
}

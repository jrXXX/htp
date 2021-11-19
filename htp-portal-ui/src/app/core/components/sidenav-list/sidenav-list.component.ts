import {
  ChangeDetectionStrategy,
  Component,
  EventEmitter,
  Input,
  Output,
} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'akros-sidenav-list',
  templateUrl: './sidenav-list.component.html',
  styleUrls: ['./sidenav-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SidenavListComponent {
  @Output()
  onToggleSideNavBar = new EventEmitter<any>();

  @Input()
  currentUrl: string;

  constructor(public route: Router) {}
}

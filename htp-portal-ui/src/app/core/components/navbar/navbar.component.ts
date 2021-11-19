import {
  ChangeDetectionStrategy,
  Component,
  EventEmitter,
  Input,
  Output,
} from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'akros-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class NavbarComponent {
  @Output()
  onSideNavToggle = new EventEmitter();

  @Output()
  onLogin = new EventEmitter();

  @Output()
  onLogout = new EventEmitter();

  @Input()
  isLogin: boolean;

  @Input()
  isLogout: boolean;

  @Input()
  accountName: string;

  @Input()
  languageTranslate: TranslateService;
}

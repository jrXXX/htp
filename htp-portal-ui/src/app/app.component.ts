import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { AuthStoreService } from './core/services/auth-store/auth-store.service';
import { Observable } from 'rxjs';
import { AccountInfo } from '@azure/msal-common';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  account$: Observable<AccountInfo>;

  constructor(
    public translate: TranslateService,
    public authstoreService: AuthStoreService
  ) {
    translate.addLangs(['en', 'de', 'fr']);
    translate.use('de');
  }

  ngOnInit(): void {
    this.account$ = this.authstoreService.accountInfo$;
  }

  login = (): void => {
    this.authstoreService.login().subscribe(
      () => {},
      (error) => {
        alert('login failed');
      }
    );
  };

  logout = (): void => {
    this.authstoreService.logout();
  };
}

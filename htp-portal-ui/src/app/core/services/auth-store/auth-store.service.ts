import { Injectable } from '@angular/core';
import { MsalService as AuthService } from '@azure/msal-angular';
import { AccountInfo } from '@azure/msal-common';
import { BehaviorSubject, Observable } from 'rxjs';
import { map, shareReplay, tap } from 'rxjs/operators';

const AUTH_DATA = 'auth_data';

@Injectable({
  providedIn: 'root',
})
export class AuthStoreService {
  private authStoreSubject = new BehaviorSubject<AccountInfo>(null);
  accountInfo$: Observable<AccountInfo> = this.authStoreSubject.asObservable();
  isLoggin$: Observable<boolean>;
  isLoggedOut$: Observable<boolean>;

  constructor(private authService: AuthService) {
    this.isLoggin$ = this.accountInfo$.pipe(map((account) => !!account));
    this.isLoggedOut$ = this.isLoggin$.pipe(map((isloggin) => !isloggin));
    const accountInfo = localStorage.getItem(AUTH_DATA);
    if (accountInfo) {
      this.authStoreSubject.next(JSON.parse(accountInfo));
    }
  }

  login(): Observable<any> {
    return this.authService.loginPopup().pipe(
      tap((authenticationResult) => {
        this.authStoreSubject.next(authenticationResult.account);
        localStorage.setItem(
          AUTH_DATA,
          JSON.stringify(authenticationResult.account)
        );
      }),
      shareReplay()
    );
  }
  
  logout(): void {
    this.authStoreSubject.next(null);
    localStorage.removeItem(AUTH_DATA);
  }
}

import { TestBed } from '@angular/core/testing';

import { MsalService as AuthService } from '@azure/msal-angular';
import { AuthStoreService } from './auth-store.service';

describe('AuthStoreService', () => {
  //let service: AuthStoreService;
  let mockAuthStoreService;

  beforeEach(() => {
    mockAuthStoreService = jasmine.createSpyObj(['loginPopup']);
    TestBed.configureTestingModule({
      providers: [
        AuthStoreService,
        {
          provide: AuthService,
          useValue: mockAuthStoreService,
        },
      ],
    });
    // service = TestBed.inject(AuthStoreService);
  });

  /*  it('should be created', () => {
    expect(service).toBeTruthy();
  }); */
});

import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CoreModule } from '@angular/flex-layout';
import { RouterTestingModule } from '@angular/router/testing';
import { TranslateModule } from '@ngx-translate/core';
import { of } from 'rxjs';

import { AppComponent } from './app.component';
import { AuthStoreService } from './core/services';

describe('AppComponent', () => {
  let fixture: ComponentFixture<AppComponent>;
  let mockAuthStoreService;

  beforeEach(async () => {
    mockAuthStoreService = jasmine.createSpyObj(['login', 'logout']);
    await TestBed.configureTestingModule({
      imports: [RouterTestingModule, TranslateModule.forRoot(), CoreModule],
      declarations: [AppComponent],
      providers: [
        {
          provide: AuthStoreService,
          useValue: mockAuthStoreService,
        },
      ],
    }).compileComponents();
    fixture = TestBed.createComponent(AppComponent);
  });

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  it('login "AuthStoreService" should be called ', () => {
    mockAuthStoreService.login.and.returnValue(of({}));

    fixture.componentInstance.login();

    expect(mockAuthStoreService.login).toHaveBeenCalled();
  });

  it('logout "AuthstoreService" should be called', () => {
    mockAuthStoreService.logout.and.returnValue(of('login failed'));

    fixture.componentInstance.logout();

    expect(mockAuthStoreService.logout).toHaveBeenCalled();
  });
});

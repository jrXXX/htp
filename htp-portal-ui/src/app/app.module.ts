import { BrowserModule } from '@angular/platform-browser';
import { LOCALE_ID, NgModule } from '@angular/core';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { HomePageComponent } from './pages/home/containers/home-page/home-page.component';
import { AboutPageComponent } from './pages/about/containers/about-page/about-page.component';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import {
  HTTP_INTERCEPTORS,
  HttpClient,
  HttpClientModule,
} from '@angular/common/http';
import { ApiModule } from './api';
import { registerLocaleData } from '@angular/common';
import localeDECH from '@angular/common/locales/de-CH';
import {
  MSAL_INSTANCE,
  MSAL_INTERCEPTOR_CONFIG,
  MsalInterceptor,
  MsalInterceptorConfiguration,
  MsalService,
} from '@azure/msal-angular';
import {
  BrowserCacheLocation,
  InteractionType,
  IPublicClientApplication,
  PublicClientApplication,
} from '@azure/msal-browser';

import { SharedModule } from './shared/shared.module';
import { HotelSearchModule } from './pages/hotel-search/hotel-search.module';
import { CoreModule } from './core/core.module';
import { RouterModule, Routes } from '@angular/router';
import { ErrorPageComponent } from './pages/error/containers/error-page/error-page.component';
import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { reducers, metaReducers } from './store';
import { environment } from '../environments/environment';
import { EffectsModule } from '@ngrx/effects';
import { StoreRouterConnectingModule } from '@ngrx/router-store';

export function HttpLoaderFactory(http: HttpClient): TranslateHttpLoader {
  return new TranslateHttpLoader(http);
}

export const MsalInstanceFactory: () => IPublicClientApplication = () => {
  return new PublicClientApplication({
    auth: {
      clientId: environment.signOn.clientId,
      authority: environment.signOn.authority,
      redirectUri: environment.ownUrl,
    },
    cache: {
      cacheLocation: BrowserCacheLocation.LocalStorage,
    },
  });
};

export function MsalInterceptorConfigFactory(): MsalInterceptorConfiguration {
  const protectedResourceMap = new Map<string, Array<string>>();
  // TODO Put protected resources here, once the application is registered
  return {
    interactionType: InteractionType.Popup,
    protectedResourceMap,
  };
}

const ROUTES: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'home',
  },
  {
    path: 'home',
    component: HomePageComponent,
  },
  {
    path: 'about',
    component: AboutPageComponent,
  },
  {
    path: 'error',
    component: ErrorPageComponent,
  },
  {
    path: 'hotel-search',
    loadChildren: () =>
      import('./pages/hotel-search/hotel-search.module').then(
        (m) => m.HotelSearchModule
      ),
  },
];

registerLocaleData(localeDECH);

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    ErrorPageComponent,
    AboutPageComponent,
  ],
  imports: [
    BrowserModule,
    TranslateModule.forRoot({
      defaultLanguage: 'de',
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient],
      },
    }),
    RouterModule.forRoot(ROUTES),
    ApiModule,
    BrowserAnimationsModule,
    HttpClientModule,
    HotelSearchModule,
    SharedModule,
    CoreModule,
    StoreModule.forRoot({}, {}),
    StoreDevtoolsModule.instrument({
      maxAge: 25,
      logOnly: environment.production,
    }),
    StoreModule.forRoot(reducers, { metaReducers }),
    !environment.production ? StoreDevtoolsModule.instrument() : [],
    EffectsModule.forRoot([]),
    StoreRouterConnectingModule.forRoot(),
  ],
  providers: [
    {
      provide: LOCALE_ID,
      useValue: 'de-ch',
    },
    {
      provide: MSAL_INSTANCE,
      useFactory: MsalInstanceFactory,
    },
    MsalService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: MsalInterceptor,
      multi: true,
    },
    {
      provide: MSAL_INTERCEPTOR_CONFIG,
      useFactory: MsalInterceptorConfigFactory,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}

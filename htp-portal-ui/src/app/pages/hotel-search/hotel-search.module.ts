import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ReactiveFormsModule } from '@angular/forms';

import { RouterModule, Routes } from '@angular/router';
import { CoreModule } from 'src/app/core/core.module';
import { SharedModule } from 'src/app/shared/shared.module';

import * as fromSharedModuleComponent from './../../shared/components';
import * as fromServices from './commons/services';
import * as fromComponents from './components';
import * as fromContainers from './containers';
import * as fromEffects from './store/effects';
import { StoreModule } from '@ngrx/store';
import { reducer } from './store/reducers/hotel.-reducer';
import { EffectsModule } from '@ngrx/effects';
import { transformBackendImagesPipe } from './commons/utils/utils';
 
export const ROUTES: Routes = [
  {
    path: 'hotel-search',
    component: fromContainers.HotelPageSearchComponent,
  },
];

@NgModule({
  declarations: [
    ...fromContainers.containers,
    fromSharedModuleComponent.LoadingComponent,
    ...fromComponents.components,
    transformBackendImagesPipe
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    EffectsModule.forFeature(fromEffects.effects),
    StoreModule.forFeature('hotel', reducer),
    CoreModule,
    SharedModule,
    RouterModule.forChild(ROUTES),
  ],
  providers: [...fromServices.services],
  exports: [...fromContainers.containers],
})
export class HotelSearchModule {}

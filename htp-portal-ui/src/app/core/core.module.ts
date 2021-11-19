import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { RouterModule } from '@angular/router';
import * as fromCoreService from './services';
import * as fromCoreComponents from './components';

@NgModule({
  declarations: [...fromCoreComponents.components],
  imports: [CommonModule, RouterModule, SharedModule],
  providers: [...fromCoreService.services],
  exports: [...fromCoreComponents.components],
})
export class CoreModule {}

import { NgModule } from '@angular/core';

import { SharedModule } from 'src/app/shared/modules/shared.module';

import { SportsComponent } from './sports.component';
import { SportComponent } from './sport/sport.component';

@NgModule({
  declarations: [SportsComponent, SportComponent],
  imports: [SharedModule],
  exports: [SportsComponent]
})
export class SportsModule {}

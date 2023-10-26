import { NgModule } from '@angular/core';

import { SharedModule } from 'src/app/shared/modules/shared.module';

import { TeamsComponent } from './teams.component';
import { TeamComponent } from './team/team.component';
import { PlayerCardComponent } from './player-card/player-card.component';
import { AddPlayerModalComponent } from './add-player/add-player-modal.component';
import { AddDepthModalComponent } from './add-depth/add-depth-modal.component';
import { DepthTableComponent } from './depth-table/depth-table.component';
import { PlayerDepthCardComponent } from './player-depth-card/player-depth-card.component';
import { PlayerDetailsModalComponent } from './player-details/player-details-modal.component';

@NgModule({
  declarations: [
    TeamsComponent,
    TeamComponent,
    PlayerCardComponent,
    AddPlayerModalComponent,
    AddDepthModalComponent,
    DepthTableComponent,
    PlayerDepthCardComponent,
    PlayerDetailsModalComponent,
  ],
  imports: [SharedModule],
  exports: [TeamsComponent]
})
export class TeamsModule {}

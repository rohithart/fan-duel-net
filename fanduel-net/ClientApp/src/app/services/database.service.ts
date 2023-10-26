import { Injectable } from '@angular/core';

import { sportsData } from 'src/app/data/sports';
import { teamsData } from 'src/app/data/teams';
import { playerData } from 'src/app/data/player';
import { Team } from 'src/app/models/Team';
import { Sport } from 'src/app/models/Sport';
import { Player } from 'src/app/models/Player';

@Injectable({
  providedIn: 'root'
})
export class DatabaseService {
    getSports(): Promise<Sport[]> {
      return Promise.resolve(sportsData);
    }

    getTeams(): Promise<Team[]> {
      return Promise.resolve(teamsData);
    }

    getPlayers(): Promise<Player[]> {
      return Promise.resolve(playerData);
    }

    addPlayer(player: Player) {
      return Promise.resolve(playerData.push(player));
    }
}

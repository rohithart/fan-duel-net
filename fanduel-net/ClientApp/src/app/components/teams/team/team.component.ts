import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

import { Player } from 'src/app/models/Player';
import { Team } from 'src/app/models/Team';
import { PlayerService } from 'src/app/services/player.service';
import { TeamService } from 'src/app/services/team.service';
import { AddPlayerModalComponent } from '../add-player/add-player-modal.component';
import { AddDepthModalComponent } from '../add-depth/add-depth-modal.component';
import { TeamDepth } from 'src/app/models/TeamDepth';
import { DepthService } from 'src/app/services/depth.service';

@Component({
  selector: 'app-team',
  templateUrl: './team.component.html',
  styleUrls: ['./team.component.scss']
})
export class TeamComponent implements OnInit {
  teamId = '';
  team?: Team;
  depth!: TeamDepth;
  players: Player[] = [];

  constructor(
    private toast: ToastrService,
    private dialog: MatDialog,
    private route: ActivatedRoute,
    private teamsService: TeamService,
    private depthService: DepthService,
    private playerService: PlayerService) {}

  ngOnInit(): void {
    this.teamId = this.route.snapshot.params['id'] || '';
    this.refresh();
  }

  refresh() {
    this.getData();
  }

  playerSelected(player: Player) {
    const dialogRef = this.dialog.open(AddDepthModalComponent, {
      width: '40rem',
      data: {
        player: player,
      }
    });

    dialogRef.afterClosed().subscribe((result: any) => {
      if (result) {
        let data = {
          playerId: player.id,
          position: result.position,
          depth: result.depth,
        }
        this.depthService.addPlayerToDepthChart(this.teamId, data).subscribe((data) => {
          this.toast.success(`${player.name} added to depth chart`, 'Success');
          this.refresh();
        });
      }
    });
  }

  addPlayer() {
    const dialogRef = this.dialog.open(AddPlayerModalComponent, {
      width: '40rem',
      data: {
        team: this.team,
      }
    });

    dialogRef.afterClosed().subscribe((result: Player) => {
      if (result) {
        const playerIndex = this.players.findIndex((p) => p.num === result.num);
        if(playerIndex === -1) {
          this.playerService.addPlayer(result).subscribe(() => {
            this.toast.success('New player has been added', 'Success');
            this.getPlayers();
          });
        } else {
          this.toast.error(`Player with number ${result.num} already exists`, 'Error');
        }
      }
    });
  }

  private getData() {
    this.teamsService.getTeam(this.teamId).subscribe((team) => {
      if(team != null) {
        this.team = team;
        this.getPlayers();
        this.initDepth();
      }
    })
  }

  private initDepth() {
    if(this.team) {
      this.depthService.getTeamDepth(this.team.id).subscribe((data) => {
        this.depth = data;
      })
    }

  }

  private getPlayers() {
    if(this.team) {
      this.playerService.getAllPlayers(this.team.id).subscribe((data) => {
        this.players = data.sort((a,b) => a.name.localeCompare(b.name));
      })
    }
  }
}

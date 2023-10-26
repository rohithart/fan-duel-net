import { EventEmitter } from '@angular/core';
import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Player } from 'src/app/models/Player';
import { TeamDepth } from 'src/app/models/TeamDepth';
import { DepthService } from 'src/app/services/depth.service';

@Component({
  selector: 'app-player-details-modal',
  templateUrl: './player-details-modal.component.html',
  styleUrls: ['./player-details-modal.component.scss']
})
export class PlayerDetailsModalComponent implements OnInit {
  backups: Player[] = [];

  constructor(
    private depthService: DepthService,
    public dialogRef: MatDialogRef<PlayerDetailsModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { player: Player, depth: number, position: string, teamDepth: TeamDepth, refreshEmitter: EventEmitter<any>}
  ) {}

  ngOnInit(): void {
    this.getBackUps();
  }

  onYesClick(): void {
    this.dialogRef.close();
  }

  removePlayer(): void {
    const data = {
      playerId: this.data.player.id,
      position: this.data.position,
    }
    this.depthService.removePlayerToDepthChart(this.data.teamDepth.team.id, data).subscribe((data) => {
      this.data.refreshEmitter.emit();
      this.dialogRef.close();
    })
  }


  private getBackUps() {
    const data = {
      playerId: this.data.player.id,
      position: this.data.position,
    }
    this.depthService.getBackups(this.data.teamDepth.team.id, data).subscribe((data) => {
      this.backups = data;
    })
  }
}

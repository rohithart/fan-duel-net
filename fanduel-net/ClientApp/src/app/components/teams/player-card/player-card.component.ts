import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Player } from 'src/app/models/Player';

@Component({
  selector: 'app-player-card',
  templateUrl: './player-card.component.html',
  styleUrls: ['./player-card.component.scss']
})
export class PlayerCardComponent {
  @Input() player!: Player;
  @Output() playerEmitter = new EventEmitter<Player>();

  selectPlayer(player: Player) {
    this.playerEmitter.emit(player);
  }
}

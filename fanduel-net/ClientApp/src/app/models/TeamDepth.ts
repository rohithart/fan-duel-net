import { Player } from './Player';
import { Team } from './Team';

export interface TeamDepth {
  id: string;
  team: Team;
  depthChart: { [position: string]: Player[] };
}

import { Team } from './Team';

export class Player {
  id: string;
  num: number;
  name: string;
  team: Team

  constructor(id: string, num: number, name: string, team: Team) {
    this.id = id;
    this.num = num;
    this.name = name;
    this.team = team;
  }
}

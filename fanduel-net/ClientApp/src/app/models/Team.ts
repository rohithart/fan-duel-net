import { Sport } from './Sport';

export class Team {
  id: string;
  name: string;
  sport: Sport;

  constructor(id: string, name: string, sport: Sport) {
    this.id = id;
    this.name = name;
    this.sport = sport;
  }
}

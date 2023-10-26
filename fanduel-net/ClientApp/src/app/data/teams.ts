import { Team } from 'src/app/models/Team';
import { nfl, soccer } from './sports';

export const manu = new Team('1', 'Manchester United', soccer);
export const miami = new Team('2', 'Inter Miami', soccer);

export const nyg = new Team('3', 'NewYork Giants', nfl);
export const pe = new Team('4', 'Philadelphia Eagles', nfl);
export const tampa = new Team('5', 'Tampa Bay', nfl);

export const teamsData: Team[] = [
  manu,
  miami,
  nyg,
  pe,
  tampa,
]

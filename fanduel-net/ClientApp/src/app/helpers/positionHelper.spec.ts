import { Team } from 'src/app/models/Team';
import { NFL_POSITION } from 'src/app/enums/nfl_position';
import { SOCCER_POSITION } from 'src/app/enums/soccer_position';
import { getPositionsOf } from './positionHelper';

describe('Position helper', () => {
  describe('#getPositionsOf', () => {
    describe('when the team is from soccer', () => {
      it('should return sorted soccer positions', () => {
        const soccerTeam: Team = { sport: { name: 'soccer'} } as Team;
        const positions = getPositionsOf(soccerTeam);
        const expectedPositions = Object.values(SOCCER_POSITION).sort();

        expect(positions).toEqual(expectedPositions);
      });
    });

    describe('when the team is from NFL', () => {
      it('should return sorted NFL positions', () => {
        const nflTeam: Team = { sport: { name: 'nfl'} } as Team;
        const positions = getPositionsOf(nflTeam);
        const expectedPositions = Object.values(NFL_POSITION).sort();

        expect(positions).toEqual(expectedPositions);
      });
    });

    describe('when the sport is not found', () => {
      it('should return an array with "Default" position', () => {
        const otherSport: Team = { sport: { name: 'unknown' } } as Team;
        const positions = getPositionsOf(otherSport);
        const expectedPositions = ['Default'];

        expect(positions).toEqual(expectedPositions);
      });
    });
  });
});

import { Player } from 'src/app/models/Player';
import { miami, tampa } from './teams';

const messi = new Player('1', 10, 'Lionel Messi', miami);
const yaldin = new Player('2', 2, 'DeAndre Yedlin', miami);

const brady =  new Player('3', 12, 'Tom Brady', tampa);
const gabbert =  new Player('4', 11, 'Blaine Gabbert', tampa);
const trask =  new Player('5', 2, 'Kyle Trask', tampa);
const evans =  new Player('6', 13, 'Mike Evans', tampa);
const darden =  new Player('7', 1, 'Jaelon Darden', tampa);
const miller =  new Player('8', 10, 'Scott Miller', tampa);

export const playerData = [
  messi,
  yaldin,
  brady,
  gabbert,
  trask,
  evans,
  darden,
  miller
]

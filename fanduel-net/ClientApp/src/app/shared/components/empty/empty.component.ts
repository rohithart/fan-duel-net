import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-empty',
  templateUrl: './empty.component.html',
  styleUrls: ['./empty.component.scss']
})
export class EmptyComponent {
  @Input() icon = '';
  @Input() message1 = '';
  @Input() message2 = '';
}

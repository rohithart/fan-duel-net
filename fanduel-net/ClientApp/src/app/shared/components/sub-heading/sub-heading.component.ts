import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-sub-heading',
  templateUrl: './sub-heading.component.html',
  styleUrls: ['./sub-heading.component.scss']
})
export class SubHeadingComponent {
  @Input() heading = '';
}

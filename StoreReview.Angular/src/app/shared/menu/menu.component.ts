import { Component, Input, Output,EventEmitter} from '@angular/core';
@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent {

  @Input() isOpenMenu = false;
  @Output() openMenu = new EventEmitter();

  constructor() {
  }

}

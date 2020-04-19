import { Component, OnInit, Input } from '@angular/core';
import { HeaderMessage } from '../../../model/shell/header/HeaderMessage';

@Component({
  selector: 'app-header-message-menu',
  templateUrl: './header-message-menu.component.html',
  styleUrls: ['./header-message-menu.component.css']
})
export class HeaderMessageMenuComponent implements OnInit {

  @Input() headerMessageArr: HeaderMessage[] = [];

  constructor() {
  }

  ngOnInit() {
  }

}

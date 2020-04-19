import { Component, OnInit, Input } from '@angular/core';
import { HeaderMessage } from '../../../model/shell/header/HeaderMessage';

@Component({
  selector: 'app-header-message',
  templateUrl: './header-message.component.html',
  styleUrls: ['./header-message.component.css']
})
export class HeaderMessageComponent implements OnInit {

  @Input() headerMessage: HeaderMessage;

  constructor() { }

  ngOnInit() {
  }

}

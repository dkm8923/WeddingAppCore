import { Component, OnInit, Input } from '@angular/core';
import { HeaderNotification } from '../../../model/shell/header/HeaderNotification';

@Component({
  selector: 'app-header-notification-menu',
  templateUrl: './header-notification-menu.component.html',
  styleUrls: ['./header-notification-menu.component.css']
})
export class HeaderNotificationMenuComponent implements OnInit {

  @Input() headerNotificationArr: HeaderNotification[] = [];

  constructor() { }

  ngOnInit() {
  }

}

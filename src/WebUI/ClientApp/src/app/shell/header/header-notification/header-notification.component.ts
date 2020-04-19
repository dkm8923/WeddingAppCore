import { Component, OnInit, Input } from '@angular/core';
import { HeaderNotification } from '../../../model/shell/header/HeaderNotification';

@Component({
  selector: 'app-header-notification',
  templateUrl: './header-notification.component.html',
  styleUrls: ['./header-notification.component.css']
})
export class HeaderNotificationComponent implements OnInit {

  @Input() headerNotification: HeaderNotification;

  constructor() { }

  ngOnInit() {
  }

}

import { HeaderMessage } from './HeaderMessage';
import { HeaderNotification } from './HeaderNotification';

export class HeaderBaseModel {
  constructor(showHeaderSearchBar: boolean, showHeaderMessages: boolean, showHeaderNotifications: boolean, showHeaderRightMenuToggle: boolean, headerMessageArr?: HeaderMessage[], headerNotificationArr?: HeaderNotification[]) {
    this.showHeaderSearchBar = showHeaderSearchBar;
    this.showHeaderMessages = showHeaderMessages;
    this.showHeaderNotifications = showHeaderNotifications;
    this.showHeaderRightMenuToggle = showHeaderRightMenuToggle;
    this.headerMessageArr = headerMessageArr;
    this.headerNotificationArr = headerNotificationArr;
  }

  public showHeaderSearchBar: boolean;
  public showHeaderMessages: boolean;
  public showHeaderNotifications: boolean;
  public showHeaderRightMenuToggle: boolean;
  public headerMessageArr?: HeaderMessage[];
  public headerNotificationArr?: HeaderNotification[];
}

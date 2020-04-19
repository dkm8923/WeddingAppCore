export class HeaderNotification {
  constructor(notificationCt: number, notificationType: string, notificationIconCss: string, createdOn: string) {
    this.notificationCt = notificationCt;
    this.notificationType = notificationType;
    this.notificationIconCss = notificationIconCss;
    this.createdOn = createdOn;
  }

  public notificationCt: number;
  public notificationType: string;
  public notificationIconCss: string;
  public createdOn: string;
}

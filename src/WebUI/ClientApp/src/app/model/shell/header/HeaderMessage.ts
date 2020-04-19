export class HeaderMessage {
  constructor(userName: string, userImgUrl: string, subject: string, createdOn: string) {
    this.userName = userName;
    this.userImgUrl = userImgUrl;
    this.subject = subject;
    this.createdOn = createdOn;
  }

  public userName: string;
  public userImgUrl: string;
  public subject: string;
  public createdOn: string;
}

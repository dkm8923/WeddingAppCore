export class NavLinkUserProfile
{
  constructor(userProfileImgSrc: string, userFullName: string) {
    this.userProfileImgSrc = userProfileImgSrc;
    this.userFullName = userFullName;
  }

  public userProfileImgSrc: string;
  public userFullName: string;
}

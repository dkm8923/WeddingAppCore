export class NavLink
{
  constructor(text: string, url: string, fontAwesomeCss?: string, badgeText?: string) {
    this.text = text;
    this.url = url;
    this.fontAwesomeCss = fontAwesomeCss;
    this.badgeText = badgeText;
  }

  public text: string;
  public fontAwesomeCss?: string;
  public url: string;
  public badgeText?: string;
}

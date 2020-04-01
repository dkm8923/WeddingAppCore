import { NavLink } from './NavLink';

export class NavLinkSection {
  constructor(sectionText: string, navLinks: NavLink[], fontAwesomeCss?: string, badgeText?: string) {
    this.sectionText = sectionText;
    this.navLinks = navLinks;
    this.fontAwesomeCss = fontAwesomeCss;
    this.badgeText = badgeText;
  }

  public sectionText: string;
  public fontAwesomeCss?: string;
  public badgeText?: string;
  public navLinks: NavLink[];
}

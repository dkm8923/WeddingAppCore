import { NavLinkUserProfile } from '../nav/NavLinkUserProfile';
import { NavLinkHome } from '../nav/NavLinkHome';
import { NavLinkSection } from '../nav/NavLinkSection';

export class LeftNavBaseModel {
  constructor(navLinkSection: NavLinkSection[], navLinkHome: NavLinkHome, navLinkUserProfile: NavLinkUserProfile) {
    this.navLinkSection = navLinkSection;
    this.navLinkHome = navLinkHome;
    this.navLinkUserProfile = navLinkUserProfile;
  }

  public navLinkSection: NavLinkSection[] = [];
  public navLinkHome: NavLinkHome;
  public navLinkUserProfile: NavLinkUserProfile;
}

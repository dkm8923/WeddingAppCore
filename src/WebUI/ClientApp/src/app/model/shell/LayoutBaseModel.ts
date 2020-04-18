import { LeftNavBaseModel } from '../shell/left-nav/LeftNavBaseModel';
import { Footer } from '../shell/footer/Footer';

export class LayoutBaseModel {
  constructor(leftNavBaseModel: LeftNavBaseModel, footer: Footer) {
    this.leftNavBaseModel = leftNavBaseModel;
    this.footer = footer;
  }

  public leftNavBaseModel: LeftNavBaseModel;
  public footer: Footer;
}

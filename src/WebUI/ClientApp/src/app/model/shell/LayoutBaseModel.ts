import { LeftNavBaseModel } from '../shell/left-nav/LeftNavBaseModel';
import { FooterBaseModel } from '../shell/footer/FooterBaseModel';
import { HeaderBaseModel } from '../shell/header/HeaderBaseModel';

export class LayoutBaseModel {
  constructor(leftNavBaseModel: LeftNavBaseModel, footerBaseModel: FooterBaseModel, headerBaseModel: HeaderBaseModel) {
    this.leftNavBaseModel = leftNavBaseModel;
    this.footerBaseModel = footerBaseModel;
    this.headerBaseModel = headerBaseModel;
  }

  public leftNavBaseModel: LeftNavBaseModel;
  public footerBaseModel: FooterBaseModel;
  public headerBaseModel: HeaderBaseModel;
}

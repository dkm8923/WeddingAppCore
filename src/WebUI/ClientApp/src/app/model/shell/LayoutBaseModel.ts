import { LeftNavBaseModel } from '../shell/left-nav/LeftNavBaseModel';
import { UiAppSettingFooterDto } from '../../model/dto/wedding-api-models'
import { HeaderBaseModel } from '../shell/header/HeaderBaseModel';

export class LayoutBaseModel {
  constructor(leftNavBaseModel: LeftNavBaseModel, footerBaseModel: UiAppSettingFooterDto, headerBaseModel: HeaderBaseModel) {
    this.leftNavBaseModel = leftNavBaseModel;
    this.footerBaseModel = footerBaseModel;
    this.headerBaseModel = headerBaseModel;
  }

  public leftNavBaseModel: LeftNavBaseModel;
  public footerBaseModel: UiAppSettingFooterDto;
  public headerBaseModel: HeaderBaseModel;
}

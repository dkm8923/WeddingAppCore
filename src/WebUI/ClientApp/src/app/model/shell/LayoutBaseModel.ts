import { LeftNavBaseModel } from '../../model/shell/left-nav/LeftNavBaseModel';

export class LayoutBaseModel {
  constructor(leftNavBaseModel: LeftNavBaseModel) {
    this.leftNavBaseModel = leftNavBaseModel;
  }

  public leftNavBaseModel: LeftNavBaseModel;
}

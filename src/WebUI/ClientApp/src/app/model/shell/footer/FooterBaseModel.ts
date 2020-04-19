export class FooterBaseModel
{
  constructor(leftText: string, middleText: string, rightText?: string) {
    this.leftText = leftText;
    this.middleText = middleText;
    this.rightText = rightText;
  }

  public leftText: string;
  public middleText?: string;
  public rightText?: string;
}

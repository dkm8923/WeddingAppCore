import { Component, OnInit, Input } from '@angular/core';
import { UiAppSettingFooterDto } from '../../model/dto/wedding-api-models'

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

  @Input() footerBaseModel: UiAppSettingFooterDto;
  listItemCt: number = 0;
  ulCss: string;

  constructor() {
  }

  ngOnInit() {
    this.checkForTextVal(this.footerBaseModel.textLeft);
    this.checkForTextVal(this.footerBaseModel.textMiddle);
    this.checkForTextVal(this.footerBaseModel.textRight);
    this.ulCss = "li" + this.listItemCt.toString();
  }

  checkForTextVal(text) {
    if (text !== null && text !== "") {
      this.listItemCt += 1;
    }
  }
}

import { Component, OnInit, Input } from '@angular/core';
import { FooterBaseModel } from '../../model/shell/footer/FooterBaseModel'


@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

  @Input() footerBaseModel: FooterBaseModel;
  listItemCt: number = 0;
  ulCss: string;

  constructor() {
  }

  ngOnInit() {
    this.checkForTextVal(this.footerBaseModel.leftText);
    this.checkForTextVal(this.footerBaseModel.middleText);
    this.checkForTextVal(this.footerBaseModel.rightText);
    this.ulCss = "li" + this.listItemCt.toString();
  }

  checkForTextVal(text) {
    if (text !== null && text !== "") {
      this.listItemCt += 1;
    }
  }
}

import { Component, OnInit, Input } from '@angular/core';
import { Footer } from '../../model/shell/footer/Footer'


@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

  @Input() footer: Footer;
  listItemCt: number = 0;
  ulCss: string;

  constructor() {
    //this.footer = new Footer("MSS Admin UI",
    //  "Version 1.0",
    //  "Copyright 2020");
  }

  ngOnInit() {
    this.checkForTextVal(this.footer.leftText);
    this.checkForTextVal(this.footer.middleText);
    this.checkForTextVal(this.footer.rightText);
    this.ulCss = "li" + this.listItemCt.toString();
  }

  checkForTextVal(text) {
    if (text !== null && text !== "") {
      this.listItemCt += 1;
    }
  }
}

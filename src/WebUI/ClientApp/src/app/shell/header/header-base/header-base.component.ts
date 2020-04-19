import { Component, OnInit, Input } from '@angular/core';
import { HeaderBaseModel } from '../../../model/shell/header/HeaderBaseModel';

@Component({
  selector: 'app-header-base',
  templateUrl: './header-base.component.html',
  styleUrls: ['./header-base.component.css']
})
export class HeaderBaseComponent implements OnInit {

  @Input() headerBaseModel: HeaderBaseModel;

  constructor() { }

  ngOnInit() {
  }

}

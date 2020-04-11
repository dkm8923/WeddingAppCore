import { Component, OnInit, Input } from '@angular/core';
import { LeftNavBaseModel } from '../../model/shell/left-nav/LeftNavBaseModel';

@Component({
  selector: 'app-left-nav',
  templateUrl: './left-nav.component.html',
  styleUrls: ['./left-nav.component.css']
})
export class LeftNavComponent implements OnInit {

  @Input() leftNavBaseModel: LeftNavBaseModel;

  constructor() {
  }

  ngOnInit() {
  }
}

import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-layout-color-selector',
  templateUrl: './layout-color-selector.component.html',
  styleUrls: ['./layout-color-selector.component.css']
})
export class LayoutColorSelectorComponent implements OnInit {

  @Input() colorCssClass: string;

  constructor() { }

  ngOnInit() {
  }

}

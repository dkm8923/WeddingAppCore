import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LayoutColorSelectorComponent } from './layout-color-selector.component';

describe('LayoutColorSelectorComponent', () => {
  let component: LayoutColorSelectorComponent;
  let fixture: ComponentFixture<LayoutColorSelectorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LayoutColorSelectorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LayoutColorSelectorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

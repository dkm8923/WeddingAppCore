import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShellLayoutBaseComponent } from './shell-layout-base.component';

describe('ShellLayoutBaseComponent', () => {
  let component: ShellLayoutBaseComponent;
  let fixture: ComponentFixture<ShellLayoutBaseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShellLayoutBaseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShellLayoutBaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

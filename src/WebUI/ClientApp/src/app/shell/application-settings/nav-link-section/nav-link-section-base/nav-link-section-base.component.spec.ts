import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NavLinkSectionBaseComponent } from './nav-link-section-base.component';

describe('NavLinkSectionBaseComponent', () => {
  let component: NavLinkSectionBaseComponent;
  let fixture: ComponentFixture<NavLinkSectionBaseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NavLinkSectionBaseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavLinkSectionBaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

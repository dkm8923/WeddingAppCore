import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NavLinkSectionHeaderComponent } from './nav-link-section-header.component';

describe('NavLinkSectionHeaderComponent', () => {
  let component: NavLinkSectionHeaderComponent;
  let fixture: ComponentFixture<NavLinkSectionHeaderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NavLinkSectionHeaderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavLinkSectionHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

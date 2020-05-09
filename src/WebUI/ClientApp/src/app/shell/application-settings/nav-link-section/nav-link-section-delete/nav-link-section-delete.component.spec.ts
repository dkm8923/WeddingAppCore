import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NavLinkSectionDeleteComponent } from './nav-link-section-delete.component';

describe('NavLinkSectionDeleteComponent', () => {
  let component: NavLinkSectionDeleteComponent;
  let fixture: ComponentFixture<NavLinkSectionDeleteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NavLinkSectionDeleteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavLinkSectionDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

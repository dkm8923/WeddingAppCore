import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NavLinkSingleComponent } from './nav-link-single.component';

describe('NavLinkSingleComponent', () => {
  let component: NavLinkSingleComponent;
  let fixture: ComponentFixture<NavLinkSingleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NavLinkSingleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavLinkSingleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

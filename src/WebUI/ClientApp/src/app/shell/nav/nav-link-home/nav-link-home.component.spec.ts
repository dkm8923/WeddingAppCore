import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NavLinkHomeComponent } from './nav-link-home.component';

describe('NavLinkHomeComponent', () => {
  let component: NavLinkHomeComponent;
  let fixture: ComponentFixture<NavLinkHomeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NavLinkHomeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavLinkHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

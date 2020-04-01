import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NavLinkUserProfileComponent } from './nav-link-user-profile.component';

describe('NavLinkUserProfileComponent', () => {
  let component: NavLinkUserProfileComponent;
  let fixture: ComponentFixture<NavLinkUserProfileComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NavLinkUserProfileComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavLinkUserProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

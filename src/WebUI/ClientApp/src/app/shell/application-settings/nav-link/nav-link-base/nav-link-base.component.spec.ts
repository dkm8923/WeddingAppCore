import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NavLinkBaseComponent } from './nav-link-base.component';

describe('NavLinkBaseComponent', () => {
  let component: NavLinkBaseComponent;
  let fixture: ComponentFixture<NavLinkBaseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NavLinkBaseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavLinkBaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

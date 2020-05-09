import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NavLinkDeleteComponent } from './nav-link-delete.component';

describe('NavLinkDeleteComponent', () => {
  let component: NavLinkDeleteComponent;
  let fixture: ComponentFixture<NavLinkDeleteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NavLinkDeleteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavLinkDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

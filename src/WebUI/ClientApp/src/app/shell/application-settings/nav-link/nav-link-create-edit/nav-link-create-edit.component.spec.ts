import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NavLinkCreateEditComponent } from './nav-link-create-edit.component';

describe('NavLinkCreateEditComponent', () => {
  let component: NavLinkCreateEditComponent;
  let fixture: ComponentFixture<NavLinkCreateEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NavLinkCreateEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavLinkCreateEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

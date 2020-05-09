import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NavLinkSectionCreateEditComponent } from './nav-link-section-create-edit.component';

describe('NavLinkSectionCreateEditComponent', () => {
  let component: NavLinkSectionCreateEditComponent;
  let fixture: ComponentFixture<NavLinkSectionCreateEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NavLinkSectionCreateEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavLinkSectionCreateEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

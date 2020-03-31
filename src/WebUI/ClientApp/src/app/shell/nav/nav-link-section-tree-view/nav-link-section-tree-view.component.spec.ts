import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NavLinkSectionTreeViewComponent } from './nav-link-section-tree-view.component';

describe('NavLinkSectionTreeViewComponent', () => {
  let component: NavLinkSectionTreeViewComponent;
  let fixture: ComponentFixture<NavLinkSectionTreeViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NavLinkSectionTreeViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavLinkSectionTreeViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

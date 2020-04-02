import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HeaderRightMenuToggleComponent } from './header-right-menu-toggle.component';

describe('HeaderRightMenuToggleComponent', () => {
  let component: HeaderRightMenuToggleComponent;
  let fixture: ComponentFixture<HeaderRightMenuToggleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HeaderRightMenuToggleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HeaderRightMenuToggleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

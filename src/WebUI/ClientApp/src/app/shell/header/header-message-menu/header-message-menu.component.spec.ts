import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HeaderMessageMenuComponent } from './header-message-menu.component';

describe('HeaderMessageMenuComponent', () => {
  let component: HeaderMessageMenuComponent;
  let fixture: ComponentFixture<HeaderMessageMenuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HeaderMessageMenuComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HeaderMessageMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

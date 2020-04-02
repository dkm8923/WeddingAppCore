import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HeaderNotificationMenuComponent } from './header-notification-menu.component';

describe('HeaderNotificationMenuComponent', () => {
  let component: HeaderNotificationMenuComponent;
  let fixture: ComponentFixture<HeaderNotificationMenuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HeaderNotificationMenuComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HeaderNotificationMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

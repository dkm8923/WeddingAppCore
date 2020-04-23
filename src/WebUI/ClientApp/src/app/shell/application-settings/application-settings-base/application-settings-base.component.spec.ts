import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationSettingsBaseComponent } from './application-settings-base.component';

describe('ApplicationSettingsBaseComponent', () => {
  let component: ApplicationSettingsBaseComponent;
  let fixture: ComponentFixture<ApplicationSettingsBaseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ApplicationSettingsBaseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplicationSettingsBaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

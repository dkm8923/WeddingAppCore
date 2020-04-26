import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AppSettingsBaseComponent } from './app-settings-base.component';

describe('AppSettingsBaseComponent', () => {
  let component: AppSettingsBaseComponent;
  let fixture: ComponentFixture<AppSettingsBaseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AppSettingsBaseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppSettingsBaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

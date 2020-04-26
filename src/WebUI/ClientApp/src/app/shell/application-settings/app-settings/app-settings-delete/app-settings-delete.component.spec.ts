import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AppSettingsDeleteComponent } from './app-settings-delete.component';

describe('AppSettingsDeleteComponent', () => {
  let component: AppSettingsDeleteComponent;
  let fixture: ComponentFixture<AppSettingsDeleteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AppSettingsDeleteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppSettingsDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

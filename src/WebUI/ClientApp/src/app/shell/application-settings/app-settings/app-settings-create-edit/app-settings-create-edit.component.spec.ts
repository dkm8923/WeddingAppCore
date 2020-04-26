import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AppSettingsCreateEditComponent } from './app-settings-create-edit.component';

describe('AppSettingsCreateEditComponent', () => {
  let component: AppSettingsCreateEditComponent;
  let fixture: ComponentFixture<AppSettingsCreateEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AppSettingsCreateEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppSettingsCreateEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

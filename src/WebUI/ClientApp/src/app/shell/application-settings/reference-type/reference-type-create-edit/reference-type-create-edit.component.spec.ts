import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReferenceTypeCreateEditComponent } from './reference-type-create-edit.component';

describe('ReferenceTypeCreateEditComponent', () => {
  let component: ReferenceTypeCreateEditComponent;
  let fixture: ComponentFixture<ReferenceTypeCreateEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReferenceTypeCreateEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReferenceTypeCreateEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReferenceTypeDeleteComponent } from './reference-type-delete.component';

describe('ReferenceTypeDeleteComponent', () => {
  let component: ReferenceTypeDeleteComponent;
  let fixture: ComponentFixture<ReferenceTypeDeleteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReferenceTypeDeleteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReferenceTypeDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

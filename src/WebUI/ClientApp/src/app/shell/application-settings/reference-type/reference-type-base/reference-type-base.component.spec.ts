import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReferenceTypeBaseComponent } from './reference-type-base.component';

describe('ReferenceTypeBaseComponent', () => {
  let component: ReferenceTypeBaseComponent;
  let fixture: ComponentFixture<ReferenceTypeBaseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReferenceTypeBaseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReferenceTypeBaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

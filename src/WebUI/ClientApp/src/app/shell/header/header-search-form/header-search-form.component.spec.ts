import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HeaderSearchFormComponent } from './header-search-form.component';

describe('HeaderSearchFormComponent', () => {
  let component: HeaderSearchFormComponent;
  let fixture: ComponentFixture<HeaderSearchFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HeaderSearchFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HeaderSearchFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

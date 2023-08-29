import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccidentFormComponent } from './accident-form.component';

describe('AccidentFormComponent', () => {
  let component: AccidentFormComponent;
  let fixture: ComponentFixture<AccidentFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AccidentFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AccidentFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

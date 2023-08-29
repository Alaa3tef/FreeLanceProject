import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccidentCausesComponent } from './accident-causes.component';

describe('AccidentCausesComponent', () => {
  let component: AccidentCausesComponent;
  let fixture: ComponentFixture<AccidentCausesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AccidentCausesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AccidentCausesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

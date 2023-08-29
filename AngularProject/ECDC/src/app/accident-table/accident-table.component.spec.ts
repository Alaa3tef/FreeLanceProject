import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccidentTableComponent } from './accident-table.component';

describe('AccidentTableComponent', () => {
  let component: AccidentTableComponent;
  let fixture: ComponentFixture<AccidentTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AccidentTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AccidentTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

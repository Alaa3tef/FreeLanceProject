import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComminucationMethodComponent } from './comminucation-method.component';

describe('ComminucationMethodComponent', () => {
  let component: ComminucationMethodComponent;
  let fixture: ComponentFixture<ComminucationMethodComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ComminucationMethodComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ComminucationMethodComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

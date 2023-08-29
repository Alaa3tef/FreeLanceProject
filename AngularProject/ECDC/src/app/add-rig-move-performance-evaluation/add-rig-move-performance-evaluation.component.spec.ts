import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddRigMovePerformanceEvaluationComponent } from './add-rig-move-performance-evaluation.component';

describe('AddRigMovePerformanceEvaluationComponent', () => {
  let component: AddRigMovePerformanceEvaluationComponent;
  let fixture: ComponentFixture<AddRigMovePerformanceEvaluationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddRigMovePerformanceEvaluationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddRigMovePerformanceEvaluationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

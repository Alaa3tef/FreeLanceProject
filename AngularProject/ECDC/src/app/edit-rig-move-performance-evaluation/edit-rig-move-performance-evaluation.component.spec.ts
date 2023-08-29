import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditRigMovePerformanceEvaluationComponent } from './edit-rig-move-performance-evaluation.component';

describe('EditRigMovePerformanceEvaluationComponent', () => {
  let component: EditRigMovePerformanceEvaluationComponent;
  let fixture: ComponentFixture<EditRigMovePerformanceEvaluationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditRigMovePerformanceEvaluationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditRigMovePerformanceEvaluationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

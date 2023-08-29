import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RigMovePerformanceEvaluationComponent } from './rig-move-performance-evaluation.component';

describe('RigMovePerformanceEvaluationComponent', () => {
  let component: RigMovePerformanceEvaluationComponent;
  let fixture: ComponentFixture<RigMovePerformanceEvaluationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RigMovePerformanceEvaluationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RigMovePerformanceEvaluationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { TestBed } from '@angular/core/testing';

import { AddRigMovePerformanceEvaluationService } from './add-rig-move-performance-evaluation.service';

describe('AddRigMovePerformanceEvaluationService', () => {
  let service: AddRigMovePerformanceEvaluationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AddRigMovePerformanceEvaluationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

import { TestBed } from '@angular/core/testing';

import { StopCardService } from './stop-card.service';

describe('StopCardService', () => {
  let service: StopCardService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StopCardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

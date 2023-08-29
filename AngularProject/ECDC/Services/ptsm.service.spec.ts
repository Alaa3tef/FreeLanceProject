import { TestBed } from '@angular/core/testing';

import { PTSMService } from './ptsm.service';

describe('PTSMService', () => {
  let service: PTSMService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PTSMService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

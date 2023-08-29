import { TestBed } from '@angular/core/testing';

import { AddBOPService } from './add-bop.service';

describe('AddBOPService', () => {
  let service: AddBOPService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AddBOPService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

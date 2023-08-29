import { TestBed } from '@angular/core/testing';

import { AddDataService } from './add-data.service';

describe('AddDataService', () => {
  let service: AddDataService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AddDataService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

import { TestBed } from '@angular/core/testing';

import { AddNewAccidentService } from './add-new-accident.service';

describe('AddNewAccidentService', () => {
  let service: AddNewAccidentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AddNewAccidentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

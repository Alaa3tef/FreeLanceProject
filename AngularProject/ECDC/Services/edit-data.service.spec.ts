import { TestBed } from '@angular/core/testing';

import { EditDataService } from './edit-data.service';

describe('EditDataService', () => {
  let service: EditDataService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EditDataService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

import { TestBed } from '@angular/core/testing';

import { GetdataByPageService } from './getdata-by-page.service';

describe('GetdataByPageService', () => {
  let service: GetdataByPageService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GetdataByPageService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

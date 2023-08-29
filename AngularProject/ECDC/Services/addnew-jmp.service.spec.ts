import { TestBed } from '@angular/core/testing';

import { AddnewJMPService } from './addnew-jmp.service';

describe('AddnewJMPService', () => {
  let service: AddnewJMPService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AddnewJMPService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

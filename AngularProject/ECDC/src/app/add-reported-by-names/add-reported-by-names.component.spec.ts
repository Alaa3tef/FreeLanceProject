import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddReportedByNamesComponent } from './add-reported-by-names.component';

describe('AddReportedByNamesComponent', () => {
  let component: AddReportedByNamesComponent;
  let fixture: ComponentFixture<AddReportedByNamesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddReportedByNamesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddReportedByNamesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

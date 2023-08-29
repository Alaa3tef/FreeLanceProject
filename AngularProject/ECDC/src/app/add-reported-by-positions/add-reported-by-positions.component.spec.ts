import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddReportedByPositionsComponent } from './add-reported-by-positions.component';

describe('AddReportedByPositionsComponent', () => {
  let component: AddReportedByPositionsComponent;
  let fixture: ComponentFixture<AddReportedByPositionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddReportedByPositionsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddReportedByPositionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

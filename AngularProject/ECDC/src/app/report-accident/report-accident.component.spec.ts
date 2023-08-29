import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportAccidentComponent } from './report-accident.component';

describe('ReportAccidentComponent', () => {
  let component: ReportAccidentComponent;
  let fixture: ComponentFixture<ReportAccidentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReportAccidentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReportAccidentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

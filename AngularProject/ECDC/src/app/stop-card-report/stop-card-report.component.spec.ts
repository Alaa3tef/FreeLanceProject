import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StopCardReportComponent } from './stop-card-report.component';

describe('StopCardReportComponent', () => {
  let component: StopCardReportComponent;
  let fixture: ComponentFixture<StopCardReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StopCardReportComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StopCardReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

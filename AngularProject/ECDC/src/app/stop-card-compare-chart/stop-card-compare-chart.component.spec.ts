import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StopCardCompareChartComponent } from './stop-card-compare-chart.component';

describe('StopCardCompareChartComponent', () => {
  let component: StopCardCompareChartComponent;
  let fixture: ComponentFixture<StopCardCompareChartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StopCardCompareChartComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StopCardCompareChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

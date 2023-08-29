import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RigPerformanceChartComponent } from './rig-performance-chart.component';

describe('RigPerformanceChartComponent', () => {
  let component: RigPerformanceChartComponent;
  let fixture: ComponentFixture<RigPerformanceChartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RigPerformanceChartComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RigPerformanceChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

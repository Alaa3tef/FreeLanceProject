import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RigPerformanceCompareChartsComponent } from './rig-performance-compare-charts.component';

describe('RigPerformanceCompareChartsComponent', () => {
  let component: RigPerformanceCompareChartsComponent;
  let fixture: ComponentFixture<RigPerformanceCompareChartsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RigPerformanceCompareChartsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RigPerformanceCompareChartsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

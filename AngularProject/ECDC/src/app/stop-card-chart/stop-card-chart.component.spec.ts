import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StopCardChartComponent } from './stop-card-chart.component';

describe('StopCardChartComponent', () => {
  let component: StopCardChartComponent;
  let fixture: ComponentFixture<StopCardChartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StopCardChartComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StopCardChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

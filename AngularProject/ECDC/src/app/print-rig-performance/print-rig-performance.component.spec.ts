import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintRigPerformanceComponent } from './print-rig-performance.component';

describe('PrintRigPerformanceComponent', () => {
  let component: PrintRigPerformanceComponent;
  let fixture: ComponentFixture<PrintRigPerformanceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintRigPerformanceComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintRigPerformanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

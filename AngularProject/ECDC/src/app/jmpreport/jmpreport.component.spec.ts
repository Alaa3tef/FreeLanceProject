import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JMPReportComponent } from './jmpreport.component';

describe('JMPReportComponent', () => {
  let component: JMPReportComponent;
  let fixture: ComponentFixture<JMPReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ JMPReportComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JMPReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

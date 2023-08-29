import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintPTSMComponent } from './print-ptsm.component';

describe('PrintPTSMComponent', () => {
  let component: PrintPTSMComponent;
  let fixture: ComponentFixture<PrintPTSMComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintPTSMComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintPTSMComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

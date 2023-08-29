import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportedByPositionsComponent } from './reported-by-positions.component';

describe('ReportedByPositionsComponent', () => {
  let component: ReportedByPositionsComponent;
  let fixture: ComponentFixture<ReportedByPositionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReportedByPositionsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReportedByPositionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

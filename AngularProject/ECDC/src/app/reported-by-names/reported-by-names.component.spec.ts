import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportedByNamesComponent } from './reported-by-names.component';

describe('ReportedByNamesComponent', () => {
  let component: ReportedByNamesComponent;
  let fixture: ComponentFixture<ReportedByNamesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReportedByNamesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReportedByNamesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

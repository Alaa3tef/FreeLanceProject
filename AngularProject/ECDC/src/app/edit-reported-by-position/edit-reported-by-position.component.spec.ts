import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditReportedByPositionComponent } from './edit-reported-by-position.component';

describe('EditReportedByPositionComponent', () => {
  let component: EditReportedByPositionComponent;
  let fixture: ComponentFixture<EditReportedByPositionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditReportedByPositionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditReportedByPositionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

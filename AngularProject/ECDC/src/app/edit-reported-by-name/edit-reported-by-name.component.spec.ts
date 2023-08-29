import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditReportedByNameComponent } from './edit-reported-by-name.component';

describe('EditReportedByNameComponent', () => {
  let component: EditReportedByNameComponent;
  let fixture: ComponentFixture<EditReportedByNameComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditReportedByNameComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditReportedByNameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

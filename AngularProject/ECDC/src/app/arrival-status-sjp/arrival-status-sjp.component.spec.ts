import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArrivalStatusSJPComponent } from './arrival-status-sjp.component';

describe('ArrivalStatusSJPComponent', () => {
  let component: ArrivalStatusSJPComponent;
  let fixture: ComponentFixture<ArrivalStatusSJPComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ArrivalStatusSJPComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ArrivalStatusSJPComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

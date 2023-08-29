import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditStopCardComponent } from './edit-stop-card.component';

describe('EditStopCardComponent', () => {
  let component: EditStopCardComponent;
  let fixture: ComponentFixture<EditStopCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditStopCardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditStopCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

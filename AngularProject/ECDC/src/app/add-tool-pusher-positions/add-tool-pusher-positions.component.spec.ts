import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddToolPusherPositionsComponent } from './add-tool-pusher-positions.component';

describe('AddToolPusherPositionsComponent', () => {
  let component: AddToolPusherPositionsComponent;
  let fixture: ComponentFixture<AddToolPusherPositionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddToolPusherPositionsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddToolPusherPositionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

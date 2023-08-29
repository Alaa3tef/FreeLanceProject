import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToolPusherPositionsComponent } from './tool-pusher-positions.component';

describe('ToolPusherPositionsComponent', () => {
  let component: ToolPusherPositionsComponent;
  let fixture: ComponentFixture<ToolPusherPositionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToolPusherPositionsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ToolPusherPositionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

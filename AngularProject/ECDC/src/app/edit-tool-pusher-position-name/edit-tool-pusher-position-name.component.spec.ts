import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditToolPusherPositionNameComponent } from './edit-tool-pusher-position-name.component';

describe('EditToolPusherPositionNameComponent', () => {
  let component: EditToolPusherPositionNameComponent;
  let fixture: ComponentFixture<EditToolPusherPositionNameComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditToolPusherPositionNameComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditToolPusherPositionNameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

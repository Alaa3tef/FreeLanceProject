import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditToolPusherPositionComponent } from './edit-tool-pusher-position.component';

describe('EditToolPusherPositionComponent', () => {
  let component: EditToolPusherPositionComponent;
  let fixture: ComponentFixture<EditToolPusherPositionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditToolPusherPositionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditToolPusherPositionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

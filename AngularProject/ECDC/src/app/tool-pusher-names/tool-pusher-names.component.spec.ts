import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToolPusherNamesComponent } from './tool-pusher-names.component';

describe('ToolPusherNamesComponent', () => {
  let component: ToolPusherNamesComponent;
  let fixture: ComponentFixture<ToolPusherNamesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToolPusherNamesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ToolPusherNamesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

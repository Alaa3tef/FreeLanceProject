import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddToolPusherNamesComponent } from './add-tool-pusher-names.component';

describe('AddToolPusherNamesComponent', () => {
  let component: AddToolPusherNamesComponent;
  let fixture: ComponentFixture<AddToolPusherNamesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddToolPusherNamesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddToolPusherNamesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditPTSMComponent } from './edit-ptsm.component';

describe('EditPTSMComponent', () => {
  let component: EditPTSMComponent;
  let fixture: ComponentFixture<EditPTSMComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditPTSMComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditPTSMComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

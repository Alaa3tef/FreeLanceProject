import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPTSMComponent } from './add-ptsm.component';

describe('AddPTSMComponent', () => {
  let component: AddPTSMComponent;
  let fixture: ComponentFixture<AddPTSMComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddPTSMComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddPTSMComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

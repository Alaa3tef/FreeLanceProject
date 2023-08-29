import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PTSMComponent } from './ptsm.component';

describe('PTSMComponent', () => {
  let component: PTSMComponent;
  let fixture: ComponentFixture<PTSMComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PTSMComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PTSMComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

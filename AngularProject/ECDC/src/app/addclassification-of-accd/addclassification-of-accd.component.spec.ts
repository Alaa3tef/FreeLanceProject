import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddclassificationOfAccdComponent } from './addclassification-of-accd.component';

describe('AddclassificationOfAccdComponent', () => {
  let component: AddclassificationOfAccdComponent;
  let fixture: ComponentFixture<AddclassificationOfAccdComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddclassificationOfAccdComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddclassificationOfAccdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

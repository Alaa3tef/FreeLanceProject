import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddComminucationMethodComponent } from './add-comminucation-method.component';

describe('AddComminucationMethodComponent', () => {
  let component: AddComminucationMethodComponent;
  let fixture: ComponentFixture<AddComminucationMethodComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddComminucationMethodComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddComminucationMethodComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

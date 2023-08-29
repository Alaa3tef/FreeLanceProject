import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditComminucationMethodComponent } from './edit-comminucation-method.component';

describe('EditComminucationMethodComponent', () => {
  let component: EditComminucationMethodComponent;
  let fixture: ComponentFixture<EditComminucationMethodComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditComminucationMethodComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditComminucationMethodComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

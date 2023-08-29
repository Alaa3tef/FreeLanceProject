import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditClassificationOfAccidentComponent } from './edit-classification-of-accident.component';

describe('EditClassificationOfAccidentComponent', () => {
  let component: EditClassificationOfAccidentComponent;
  let fixture: ComponentFixture<EditClassificationOfAccidentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditClassificationOfAccidentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditClassificationOfAccidentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

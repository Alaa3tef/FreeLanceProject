import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditClassificationComponent } from './edit-classification.component';

describe('EditClassificationComponent', () => {
  let component: EditClassificationComponent;
  let fixture: ComponentFixture<EditClassificationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditClassificationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditClassificationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

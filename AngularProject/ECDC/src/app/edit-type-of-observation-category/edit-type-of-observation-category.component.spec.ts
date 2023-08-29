import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditTypeOfObservationCategoryComponent } from './edit-type-of-observation-category.component';

describe('EditTypeOfObservationCategoryComponent', () => {
  let component: EditTypeOfObservationCategoryComponent;
  let fixture: ComponentFixture<EditTypeOfObservationCategoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditTypeOfObservationCategoryComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditTypeOfObservationCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditViolationCategoryComponent } from './edit-violation-category.component';

describe('EditViolationCategoryComponent', () => {
  let component: EditViolationCategoryComponent;
  let fixture: ComponentFixture<EditViolationCategoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditViolationCategoryComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditViolationCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddViolationCategoriesComponent } from './add-violation-categories.component';

describe('AddViolationCategoriesComponent', () => {
  let component: AddViolationCategoriesComponent;
  let fixture: ComponentFixture<AddViolationCategoriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddViolationCategoriesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddViolationCategoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

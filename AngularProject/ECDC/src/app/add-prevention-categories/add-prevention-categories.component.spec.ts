import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPreventionCategoriesComponent } from './add-prevention-categories.component';

describe('AddPreventionCategoriesComponent', () => {
  let component: AddPreventionCategoriesComponent;
  let fixture: ComponentFixture<AddPreventionCategoriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddPreventionCategoriesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddPreventionCategoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditPreventionCategoryComponent } from './edit-prevention-category.component';

describe('EditPreventionCategoryComponent', () => {
  let component: EditPreventionCategoryComponent;
  let fixture: ComponentFixture<EditPreventionCategoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditPreventionCategoryComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditPreventionCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

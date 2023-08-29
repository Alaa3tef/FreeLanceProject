import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViolationCategoriesComponent } from './violation-categories.component';

describe('ViolationCategoriesComponent', () => {
  let component: ViolationCategoriesComponent;
  let fixture: ComponentFixture<ViolationCategoriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViolationCategoriesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViolationCategoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

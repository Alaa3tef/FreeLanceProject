import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PreventionCategoriesComponent } from './prevention-categories.component';

describe('PreventionCategoriesComponent', () => {
  let component: PreventionCategoriesComponent;
  let fixture: ComponentFixture<PreventionCategoriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PreventionCategoriesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PreventionCategoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

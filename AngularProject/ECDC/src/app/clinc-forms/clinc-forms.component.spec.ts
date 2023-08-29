import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClincFormsComponent } from './clinc-forms.component';

describe('ClincFormsComponent', () => {
  let component: ClincFormsComponent;
  let fixture: ComponentFixture<ClincFormsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClincFormsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClincFormsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

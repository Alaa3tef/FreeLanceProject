import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditTypeOfInjuryComponent } from './edit-type-of-injury.component';

describe('EditTypeOfInjuryComponent', () => {
  let component: EditTypeOfInjuryComponent;
  let fixture: ComponentFixture<EditTypeOfInjuryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditTypeOfInjuryComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditTypeOfInjuryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

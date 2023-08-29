import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddAccidentCausesComponent } from './add-accident-causes.component';

describe('AddAccidentCausesComponent', () => {
  let component: AddAccidentCausesComponent;
  let fixture: ComponentFixture<AddAccidentCausesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddAccidentCausesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddAccidentCausesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

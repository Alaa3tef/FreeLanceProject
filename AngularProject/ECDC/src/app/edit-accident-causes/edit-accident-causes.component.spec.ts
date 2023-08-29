import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditAccidentCausesComponent } from './edit-accident-causes.component';

describe('EditAccidentCausesComponent', () => {
  let component: EditAccidentCausesComponent;
  let fixture: ComponentFixture<EditAccidentCausesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditAccidentCausesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditAccidentCausesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

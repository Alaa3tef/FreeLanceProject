import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditAccidentComponent } from './edit-accident.component';

describe('EditAccidentComponent', () => {
  let component: EditAccidentComponent;
  let fixture: ComponentFixture<EditAccidentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditAccidentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditAccidentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

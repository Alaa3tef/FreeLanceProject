import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditJMLFormComponent } from './edit-jmlform.component';

describe('EditJMLFormComponent', () => {
  let component: EditJMLFormComponent;
  let fixture: ComponentFixture<EditJMLFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditJMLFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditJMLFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditRigComponent } from './edit-rig.component';

describe('EditRigComponent', () => {
  let component: EditRigComponent;
  let fixture: ComponentFixture<EditRigComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditRigComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditRigComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

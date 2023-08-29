import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditQHSEPositionComponent } from './edit-qhseposition.component';

describe('EditQHSEPositionComponent', () => {
  let component: EditQHSEPositionComponent;
  let fixture: ComponentFixture<EditQHSEPositionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditQHSEPositionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditQHSEPositionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

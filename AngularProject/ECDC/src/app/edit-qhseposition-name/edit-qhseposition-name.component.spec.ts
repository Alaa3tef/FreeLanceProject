import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditQHSEPositionNameComponent } from './edit-qhseposition-name.component';

describe('EditQHSEPositionNameComponent', () => {
  let component: EditQHSEPositionNameComponent;
  let fixture: ComponentFixture<EditQHSEPositionNameComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditQHSEPositionNameComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditQHSEPositionNameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditBOPComponent } from './edit-bop.component';

describe('EditBOPComponent', () => {
  let component: EditBOPComponent;
  let fixture: ComponentFixture<EditBOPComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditBOPComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditBOPComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

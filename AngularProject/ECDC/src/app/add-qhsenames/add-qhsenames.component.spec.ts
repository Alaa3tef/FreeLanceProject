import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddQHSENamesComponent } from './add-qhsenames.component';

describe('AddQHSENamesComponent', () => {
  let component: AddQHSENamesComponent;
  let fixture: ComponentFixture<AddQHSENamesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddQHSENamesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddQHSENamesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

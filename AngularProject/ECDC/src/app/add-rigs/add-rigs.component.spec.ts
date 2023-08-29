import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddRigsComponent } from './add-rigs.component';

describe('AddRigsComponent', () => {
  let component: AddRigsComponent;
  let fixture: ComponentFixture<AddRigsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddRigsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddRigsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

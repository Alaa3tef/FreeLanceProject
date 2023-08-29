import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddQHSEPositionsComponent } from './add-qhsepositions.component';

describe('AddQHSEPositionsComponent', () => {
  let component: AddQHSEPositionsComponent;
  let fixture: ComponentFixture<AddQHSEPositionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddQHSEPositionsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddQHSEPositionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BopTableComponent } from './bop-table.component';

describe('BopTableComponent', () => {
  let component: BopTableComponent;
  let fixture: ComponentFixture<BopTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BopTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BopTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

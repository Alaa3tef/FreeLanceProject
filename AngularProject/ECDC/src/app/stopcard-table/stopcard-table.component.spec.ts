import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StopcardTableComponent } from './stopcard-table.component';

describe('StopcardTableComponent', () => {
  let component: StopcardTableComponent;
  let fixture: ComponentFixture<StopcardTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StopcardTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StopcardTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

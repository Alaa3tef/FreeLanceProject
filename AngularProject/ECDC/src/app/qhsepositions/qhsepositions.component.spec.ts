import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QHSEPositionsComponent } from './qhsepositions.component';

describe('QHSEPositionsComponent', () => {
  let component: QHSEPositionsComponent;
  let fixture: ComponentFixture<QHSEPositionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QHSEPositionsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(QHSEPositionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

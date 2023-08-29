import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QHSENamesComponent } from './qhsenames.component';

describe('QHSENamesComponent', () => {
  let component: QHSENamesComponent;
  let fixture: ComponentFixture<QHSENamesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QHSENamesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(QHSENamesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

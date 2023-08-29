import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QSHEFormsComponent } from './qsheforms.component';

describe('QSHEFormsComponent', () => {
  let component: QSHEFormsComponent;
  let fixture: ComponentFixture<QSHEFormsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QSHEFormsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(QSHEFormsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

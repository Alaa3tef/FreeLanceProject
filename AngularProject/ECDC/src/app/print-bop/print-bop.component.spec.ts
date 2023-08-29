import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintBopComponent } from './print-bop.component';

describe('PrintBopComponent', () => {
  let component: PrintBopComponent;
  let fixture: ComponentFixture<PrintBopComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintBopComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintBopComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

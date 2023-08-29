import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BOPComponent } from './bop.component';

describe('BOPComponent', () => {
  let component: BOPComponent;
  let fixture: ComponentFixture<BOPComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BOPComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BOPComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

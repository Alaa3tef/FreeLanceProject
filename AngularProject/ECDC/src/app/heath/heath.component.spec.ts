import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HeathComponent } from './heath.component';

describe('HeathComponent', () => {
  let component: HeathComponent;
  let fixture: ComponentFixture<HeathComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HeathComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HeathComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

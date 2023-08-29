import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SJPTodayComponent } from './sjptoday.component';

describe('SJPTodayComponent', () => {
  let component: SJPTodayComponent;
  let fixture: ComponentFixture<SJPTodayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SJPTodayComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SJPTodayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

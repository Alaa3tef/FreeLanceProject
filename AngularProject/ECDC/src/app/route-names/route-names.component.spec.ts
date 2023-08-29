import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RouteNamesComponent } from './route-names.component';

describe('RouteNamesComponent', () => {
  let component: RouteNamesComponent;
  let fixture: ComponentFixture<RouteNamesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RouteNamesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RouteNamesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddRouteNamesComponent } from './add-route-names.component';

describe('AddRouteNamesComponent', () => {
  let component: AddRouteNamesComponent;
  let fixture: ComponentFixture<AddRouteNamesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddRouteNamesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddRouteNamesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditRouteNameComponent } from './edit-route-name.component';

describe('EditRouteNameComponent', () => {
  let component: EditRouteNameComponent;
  let fixture: ComponentFixture<EditRouteNameComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditRouteNameComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditRouteNameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

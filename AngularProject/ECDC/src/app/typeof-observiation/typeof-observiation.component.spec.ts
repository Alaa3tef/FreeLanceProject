import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TypeofObserviationComponent } from './typeof-observiation.component';

describe('TypeofObserviationComponent', () => {
  let component: TypeofObserviationComponent;
  let fixture: ComponentFixture<TypeofObserviationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TypeofObserviationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TypeofObserviationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddTypeofObserviationComponent } from './add-typeof-observiation.component';

describe('AddTypeofObserviationComponent', () => {
  let component: AddTypeofObserviationComponent;
  let fixture: ComponentFixture<AddTypeofObserviationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddTypeofObserviationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddTypeofObserviationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

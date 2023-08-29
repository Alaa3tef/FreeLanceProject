import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TypeofInjuriesComponent } from './typeof-injuries.component';

describe('TypeofInjuriesComponent', () => {
  let component: TypeofInjuriesComponent;
  let fixture: ComponentFixture<TypeofInjuriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TypeofInjuriesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TypeofInjuriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

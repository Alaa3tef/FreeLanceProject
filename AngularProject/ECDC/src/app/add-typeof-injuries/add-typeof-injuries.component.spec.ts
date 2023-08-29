import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddTypeofInjuriesComponent } from './add-typeof-injuries.component';

describe('AddTypeofInjuriesComponent', () => {
  let component: AddTypeofInjuriesComponent;
  let fixture: ComponentFixture<AddTypeofInjuriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddTypeofInjuriesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddTypeofInjuriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

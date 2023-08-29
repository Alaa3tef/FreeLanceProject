import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClassificationOfAccidentComponent } from './classification-of-accident.component';

describe('ClassificationOfAccidentComponent', () => {
  let component: ClassificationOfAccidentComponent;
  let fixture: ComponentFixture<ClassificationOfAccidentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClassificationOfAccidentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClassificationOfAccidentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

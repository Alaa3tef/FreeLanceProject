import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JMPFormComponent } from './jmpform.component';

describe('JMPFormComponent', () => {
  let component: JMPFormComponent;
  let fixture: ComponentFixture<JMPFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ JMPFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JMPFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

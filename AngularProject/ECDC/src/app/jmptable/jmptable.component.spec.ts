import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JMPTableComponent } from './jmptable.component';

describe('JMPTableComponent', () => {
  let component: JMPTableComponent;
  let fixture: ComponentFixture<JMPTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ JMPTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JMPTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

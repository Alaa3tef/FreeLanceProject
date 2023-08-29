import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RigsComponent } from './rigs.component';

describe('RigsComponent', () => {
  let component: RigsComponent;
  let fixture: ComponentFixture<RigsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RigsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RigsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

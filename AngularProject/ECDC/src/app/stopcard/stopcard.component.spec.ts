import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StopcardComponent } from './stopcard.component';

describe('StopcardComponent', () => {
  let component: StopcardComponent;
  let fixture: ComponentFixture<StopcardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StopcardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StopcardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

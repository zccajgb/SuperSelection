import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewCalculationsComponent } from './view-calculations.component';

describe('ViewCalcuationsComponent', () => {
  let component: ViewCalculationsComponent;
  let fixture: ComponentFixture<ViewCalculationsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewCalculationsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewCalculationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

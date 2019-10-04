import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewCalcuationsComponent } from './view-calculations.component';

describe('ViewCalcuationsComponent', () => {
  let component: ViewCalcuationsComponent;
  let fixture: ComponentFixture<ViewCalcuationsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewCalcuationsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewCalcuationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

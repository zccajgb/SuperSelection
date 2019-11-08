import { Component, OnInit, Input } from '@angular/core';
import { Calculation } from 'src/models/calculation';
import { CalculationViewModel } from 'src/models/view-models/calculation-view-model';

@Component({
  selector: 'app-calc-partial-view',
  templateUrl: './calc-partial-view.component.html',
})
export class CalcPartialViewComponent {
    @Input() public calculation: CalculationViewModel;
}

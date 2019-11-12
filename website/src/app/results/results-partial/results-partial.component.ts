import { Component, Input } from '@angular/core';
import { CalculationViewModel } from 'src/models/view-models/calculation-view-model';

@Component({
  selector: 'app-results-partial',
  templateUrl: './results-partial.component.html',
})
export class ResultsPartialComponent {
  @Input() public calculation: CalculationViewModel;
}

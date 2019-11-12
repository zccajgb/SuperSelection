import { Component, Input } from '@angular/core';
import { CalculationViewModel } from 'src/models/view-models/calculation-view-model';

@Component({
  selector: 'app-results-receptor-partial',
  templateUrl: './results-receptor-partial.component.html',
})
export class ResultsReceptorPartialComponent {
  @Input() public calculation: CalculationViewModel;
}

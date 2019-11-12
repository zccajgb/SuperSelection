import { Component, Input, OnInit } from '@angular/core';
import { CalculationViewModel } from 'src/models/view-models/calculation-view-model';

@Component({
  selector: 'app-results-ligand-partial',
  templateUrl: './results-ligand-partial.component.html',
})
export class ResultsLigandPartialComponent {
  @Input() public calculation: CalculationViewModel;
  @Input() public displayDetails: boolean[];

  showDetails(i: number) {
    this.displayDetails[i] = !this.displayDetails[i];
  }
}

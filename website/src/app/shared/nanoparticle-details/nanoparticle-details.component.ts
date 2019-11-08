
import { Component, OnInit, Input } from '@angular/core';
import { CalculationViewModel } from 'src/models/view-models/calculation-view-model';

@Component({
  selector: 'app-nanoparticle-details',
  templateUrl: './nanoparticle-details.component.html',
})
export class NanoparticleDetailsComponent {
    @Input() public calculation: CalculationViewModel;
}

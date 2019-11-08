import { Component, OnInit } from '@angular/core';
import { Result } from '../../models/result';
import { CalculationViewModel } from '../../models/view-models/calculation-view-model';
import { ResultsComponent } from '../results/results.component';
import { Title } from '@angular/platform-browser';
import { NGXLogger } from 'ngx-logger';
import { ResultsRepository } from 'src/repositories/resultsRepository';
import { Calculation } from 'src/models/calculation';

@Component({
  selector: 'app-view-calculations',
  templateUrl: './view-calculations.component.html',
  styleUrls: ['./view-calculations.component.scss']
})
export class ViewCalculationsComponent implements OnInit {

  public results: Result[] = [ { name: 'one', userID: '123', text: 'text'}, { name: 'two', userID: '123', text: 'text'} ];
  public result1: Result = { name: 'one', userID: '123', text: 'text'};
  public calculations: CalculationViewModel[];

  constructor(private title: Title, private logger: NGXLogger, private resultsRepo: ResultsRepository) {
    this.title.setTitle('View Calculations');
    this.resultsRepo = resultsRepo;
  }

  ngOnInit() {
    this.getCalculations();
  }

  getCalculations() {
    this.resultsRepo.getCalculationsForUser()
    .subscribe(calcs => this.calculations = calcs);
  }

}

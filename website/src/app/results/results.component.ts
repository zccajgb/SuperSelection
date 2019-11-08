import { Component, OnInit, Input } from '@angular/core';
import { Result } from '../../models/result';
import { Title } from '@angular/platform-browser';
import { ResultsRepository } from 'src/repositories/resultsRepository';
import { CalculationViewModel } from 'src/models/view-models/calculation-view-model';

@Component({
  selector: 'app-results',
  templateUrl: './results.component.html',
  styleUrls: ['./results.component.scss']
})
export class ResultsComponent implements OnInit {

  public result: CalculationViewModel;
  public id: string;

  constructor(private title: Title, private resultsRepo: ResultsRepository) {
    this.title.setTitle('Results');
    this.resultsRepo = resultsRepo;
  }

  ngOnInit() {
    this.resultsRepo.getCalculationByID(this.id)
    .subscribe(res => this.result = res);
  }

}

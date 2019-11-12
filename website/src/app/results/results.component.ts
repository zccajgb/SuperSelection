import { Component, OnInit, Input } from '@angular/core';
import { Result } from '../../models/result';
import { Title } from '@angular/platform-browser';
import { ResultsRepository } from 'src/repositories/resultsRepository';
import { CalculationViewModel } from 'src/models/view-models/calculation-view-model';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-results',
  templateUrl: './results.component.html',
  styleUrls: ['./results.component.scss']
})
export class ResultsComponent implements OnInit {

  public calculation: CalculationViewModel;
  public id: string;
  public displayDetails: boolean[];
  public loading = true;


  constructor(private title: Title, private route: ActivatedRoute, private resultsRepo: ResultsRepository) {
    this.title.setTitle('Results');
    this.resultsRepo = resultsRepo;
  }

  ngOnInit() {
    this.getResult();
  }


  private getResult() {
    const id = this.route.snapshot.paramMap.get('id');
    this.resultsRepo.getCalculationByID(id)
      .subscribe(res => this.setCalculation(res));
  }

  private setCalculation(res: any) {
    this.loading = false;
    this.calculation = res;
    this.displayDetails = this.calculation.ligands.map(x => false);
  }
}

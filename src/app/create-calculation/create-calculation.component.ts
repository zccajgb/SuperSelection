import { Component, OnInit } from '@angular/core';
import { Calculation } from 'src/models/calculation';

@Component({
  selector: 'app-create-calculation',
  templateUrl: './create-calculation.component.html',
  styleUrls: ['./create-calculation.component.scss']
})
export class CreateCalculationComponent implements OnInit {

  constructor() { }

  calculation : Calculation;

  ngOnInit() {
    this.calculation = new Calculation();
  }

}

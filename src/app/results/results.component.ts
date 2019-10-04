import { Component, OnInit, Input } from '@angular/core';
import { Result } from '../../models/result';

@Component({
  selector: 'app-results',
  templateUrl: './results.component.html',
  styleUrls: ['./results.component.scss']
})
export class ResultsComponent implements OnInit {

  @Input() result : Result;

  constructor() { 
  }

  ngOnInit() {
  }

}

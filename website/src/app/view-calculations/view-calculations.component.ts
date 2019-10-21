import { Component, OnInit } from '@angular/core';
import { Result } from '../../models/result';
import { ResultsComponent } from '../results/results.component';
import { Title } from '@angular/platform-browser';
import { NGXLogger } from 'ngx-logger';

@Component({
  selector: 'app-view-calculations',
  templateUrl: './view-calculations.component.html',
  styleUrls: ['./view-calculations.component.scss']
})
export class ViewCalculationsComponent implements OnInit {

  public results: Result[] = [ { name: 'one', userID: '123', text: 'text'}, { name: 'two', userID: '123', text: 'text'} ];
  public result1: Result = { name: 'one', userID: '123', text: 'text'};

  constructor(private title: Title, private logger: NGXLogger) {
    this.title.setTitle('View Calculations');
  }

  ngOnInit() {
  }

}

import { Component, OnInit, Input } from '@angular/core';
import { Result } from '../../models/result';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-results',
  templateUrl: './results.component.html',
  styleUrls: ['./results.component.scss']
})
export class ResultsComponent implements OnInit {

  @Input() result: Result;

  constructor(private title: Title) {
    this.title.setTitle('Results');
  }

  ngOnInit() {
  }

}

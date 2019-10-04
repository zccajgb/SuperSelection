import { Component, OnInit } from '@angular/core';
import { Result } from '../../models/result';

@Component({
  selector: 'app-view-calculations',
  templateUrl: './view-calculations.component.html',
  styleUrls: ['./view-calculations.component.scss']
})
export class ViewCalculationsComponent implements OnInit {

  results: Result[];

  constructor() {
    let result1 : Result = { name: "one", userID: "123", text: "text"}
    let result2 : Result = { name: "two", userID: "123", text: "text"}
    this.results = [result1, result2];
   }

  ngOnInit() {
  }

}

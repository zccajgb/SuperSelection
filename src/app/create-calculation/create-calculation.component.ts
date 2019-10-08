import { Component, OnInit } from '@angular/core';
import { Calculation } from 'src/models/calculation';
import { FormControl, FormBuilder, Validators, FormArray } from '@angular/forms';
import { stringify } from 'querystring';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-create-calculation',
  templateUrl: './create-calculation.component.html',
  styleUrls: ['./create-calculation.component.scss']
})
export class CreateCalculationComponent implements OnInit {
  calc: Calculation;
  dropdownList = ['one', 'two', 'three'];
  form: any;

  constructor(private fb: FormBuilder, private titleService: Title) {
    this.calc = new Calculation();
    this.titleService.setTitle('New Calculation');
   }

  ngOnInit() {
    this.form = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(5)]],
      text: ['', [Validators.required, Validators.minLength(5)]],
      useSomething: false,
      somethingDetails: ['', [Validators.minLength(5)]],
      dropdown: '',
      receptors: this.fb.array([this.initReceptors()])
    });
  }

  initReceptors(): any {
    return this.fb.group({
      text: ['', Validators.required]
    });
  }

  addReceptor() {
    // tslint:disable-next-line: no-string-literal
    const control = this.form.controls['receptors'] as FormArray;
    control.push(this.initReceptors());
  }

  removeReceptor(i: number) {
    // tslint:disable-next-line: no-string-literal
    const control = this.form.controls['receptors'] as FormArray;
    control.removeAt(i);
  }

}

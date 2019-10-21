import { Component, OnInit } from '@angular/core';
import { Calculation } from 'src/models/calculation';
import { FormControl, FormBuilder, Validators, FormArray } from '@angular/forms';
import { stringify } from 'querystring';
import { Title } from '@angular/platform-browser';
import { ValidatorsService } from '../_services/validators.service';
import { Router } from '@angular/router';
import { CalculationsRepository } from 'src/repositories/calculationsRepository';
import { NGXLogger } from 'ngx-logger';

@Component({
  selector: 'app-create-calculation',
  templateUrl: './create-calculation.component.html',
  styleUrls: ['./create-calculation.component.scss']
})
export class CreateCalculationComponent implements OnInit {
  dropdownList = ['one', 'two', 'three'];
  form: any;

  constructor(
    private fb: FormBuilder,
    private titleService: Title,
    private validatorService: ValidatorsService,
    private router: Router,
    private calculationsRepo: CalculationsRepository,
    private logger: NGXLogger) {
      this.titleService.setTitle('New Calculation');
      this.validatorService = validatorService;
      this.router = router;
      this.calculationsRepo = calculationsRepo;
   }

  ngOnInit() {
    this.form = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(5)]],
      numberOfLigandTypes: ['', [Validators.required, this.validatorService.isInteger]],
      insertionParameter: ['', [Validators.required, Validators.max(1), Validators.min(0)]],
      numberOfReceptors: ['', [Validators.required, this.validatorService.isInteger]],
      temperature: ['', [Validators.required]],
      nanoparticleRadius: ['', [Validators.required]],
      nanopaticleBulkConc: ['', [Validators.required]],
      // somethingDetails: ['', [Validators.minLength(5)]],
      // dropdown: '',
      // receptors: this.fb.array([this.initReceptors()])
    });
  }

  onSubmit() {
      const calc: Calculation = Object.assign({}, this.form.value);
      // tslint:disable-next-line: no-string-literal
      calc.userID = localStorage.getItem['currentUser'].userID;

      this.calculationsRepo.submitCalculation(calc)
        .subscribe(
          data => {
            this.logger.info('Calculation successfully submitted');
            this.router.navigate(['view-calculations']);
          },
          error => {
            this.logger.error(error);
          }
        );
  }

  // initReceptors(): any {
  //   return this.fb.group({
  //     text: ['', Validators.required]
  //   });
  // }

  // addReceptor() {
  //   // tslint:disable-next-line: no-string-literal
  //   const control = this.form.controls['receptors'] as FormArray;
  //   control.push(this.initReceptors());
  // }

  // removeReceptor(i: number) {
  //   // tslint:disable-next-line: no-string-literal
  //   const control = this.form.controls['receptors'] as FormArray;
  //   control.removeAt(i);
  // }

}

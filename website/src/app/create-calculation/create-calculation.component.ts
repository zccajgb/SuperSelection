import { Component, OnInit } from '@angular/core';
import { Calculation } from 'src/models/calculation';
import { FormControl, FormBuilder, Validators, FormArray, FormGroup } from '@angular/forms';
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
  public form: any;
  public page2 = false;
  public steric = false;

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
      Name: ['', [Validators.required, Validators.minLength(5)]],
      Receptors: this.fb.array([this.initReceptors()]),
      Ligands: this.fb.array([]),
      NanoparticleRadius: ['', [Validators.required]],
      NanoparticleConc: ['', [Validators.required]],
      Tolerance: ['', [Validators.required]],
      GlycolInterferenceParameter: [''],
      InterchainDistance: [''],
      useStericBrush: ['']
    });
  }

  onSubmit() {
      const calc: Calculation = Object.assign({}, this.form.value);
      if (this.form.controls.useStericBrush.value !== true) {
        calc.GlycolInterferenceParameter = 0;
        calc.InterchainDistance = 0;
      }
      // tslint:disable-next-line: no-string-literal
      // calc.userID = lo calStorage.getItem['currentUser'].userID;

      this.calculationsRepo.submitSelectivityCalculation(calc)
        .subscribe(
          data => {
            this.logger.info('Calculation successfully submitted');
            // this.router.navigate(['view-calculations']);
          },
          error => {
            this.logger.error(error);
          }
        );
  }

  initReceptors(): any {
    return this.fb.group({
      NumberOfReceptors: ['', [Validators.required]],
      InitialProbability: ['', [Validators.required, Validators.max(1), Validators.min(0)]]
    });
  }

  initLigands(receptorTypes: any): any {
    const ligands = this.fb.group({
      TetherLength: ['', Validators.required],
      NumberOfLigands: ['', Validators.required],
      InitialProbability: ['', [Validators.required, Validators.max(1), Validators.min(0)]],
      SingleBondStrength: this.initSBS(receptorTypes)
    });
    return ligands;
  }

  initSBS(receptorTypes: any): any {
    const sbs: FormArray = this.fb.array([]);
    // tslint:disable-next-line: forin
    for (const item in receptorTypes) {
        sbs.push(
          new FormControl()
        );
    }
    return sbs;
  }

  addReceptor() {
    // tslint:disable-next-line: no-string-literal
    const control = this.form.controls['Receptors'] as FormArray;
    control.push(this.initReceptors());
  }

  addLigand(receptors: any) {
    // tslint:disable-next-line: no-string-literal
    const control = this.form.controls['Ligands'] as FormArray;
    control.push(this.initLigands(receptors));
  }

  removeReceptor(i: number) {
    // tslint:disable-next-line: no-string-literal
    const control = this.form.controls['Receptors'] as FormArray;
    control.removeAt(i);
  }

  removeLigand(i: number) {
    // tslint:disable-next-line: no-string-literal
    const control = this.form.controls['Ligands'] as FormArray;
    control.removeAt(i);
  }

  next(receptors: any) {
    this.addLigand(receptors);
    this.page2 = true;
  }

  previous() {
    // tslint:disable-next-line: no-string-literal
    this.form.controls['Ligands'] = this.fb.array([]);
    this.page2 = false;
  }

}

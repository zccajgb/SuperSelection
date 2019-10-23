import { FormControl } from '@angular/forms';
import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class ValidatorsService {

   public isInteger = (control: FormControl) => {

        // here, notice we use the ternary operator to return null when value is the integer we want.
        // you are supposed to return null for the validation to pass.

        // tslint:disable-next-line: triple-equals
        return ((parseFloat(control.value) == parseInt(control.value, 10)) && !isNaN(control.value)) ? null : {
           notNumeric: true
        };
   }
}

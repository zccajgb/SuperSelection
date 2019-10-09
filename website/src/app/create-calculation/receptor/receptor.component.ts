import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
    selector: 'app-receptor',
    templateUrl: 'receptor.component.html'
})
export class ReceptorComponent {
    @Input() public receptorForm: FormGroup;
}

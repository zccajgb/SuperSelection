import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
    selector: 'app-receptor',
    templateUrl: 'receptor.component.html',
    styleUrls: ['../create-calculation.component.scss']
})
export class ReceptorComponent {
    @Input() public receptorForm: FormGroup;
    @Input() public displayOnly: boolean;
}

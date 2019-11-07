import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
    selector: 'app-ligand',
    templateUrl: 'ligand.component.html',
    styleUrls: ['../create-calculation.component.scss']
})
export class LigandComponent {
    @Input() public ligandForm: FormGroup;
    @Input() public numberOfReceptors: number;
}

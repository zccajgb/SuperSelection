import { Ligand } from '../ligand';
import { Receptor } from '../receptor';

export class CalculationViewModel {
    public name: string;
    public calculationID: string;
    public actionDateTime: Date;
    public ligands: Ligand[];
    public receptors: Receptor[];
    public nanoparticleRadius: number;
    public nanoparticleConc: number;
    public glycolInterferenceParameter: number;
    public interchainDistance: number;
    public tolerance: number;
    public bindingPartitionFunction: number;
    public volume: number;
    public stericPotential: number;
    public stericPartitionFunction: number;
    public selectivity: number;
}
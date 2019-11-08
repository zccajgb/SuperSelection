import { Ligand } from '../ligand';
import { Receptor } from '../receptor';

export class CalculationViewModel {
    public Name: string;
    public CalculationID: string;
    public ActionDateTime: Date;
    public Ligands: Ligand[];
    public Receptors: Receptor[];
    public NanoparticleRadius: number;
    public NanoparticleConc: number;
    public GlycolInterferenceParameter: number;
    public InterchainDistance: number;
    public Tolerance: number;
    public BindingPartitionFunction: number;
    public Volume: number;
    public StericPotential: number;
    public StericPartitionFunction: number;
    public Selectivity: number;
}
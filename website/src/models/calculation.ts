import { Ligand } from './ligand';
import { Receptor } from './receptor';

export class Calculation {
    public Name: string;
    public Ligands: Ligand[];
    public Receptors: Receptor[];
    public NanoparticleRadius: number;
    public NanoparticleConc: number;
    public GlycolInterferenceParameter: number;
    public InterchainDistance: number;
    public Tolerance: number;
}

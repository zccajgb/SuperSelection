namespace ApiGateway.Models.DomainModels
{
    using System.Collections.Generic;
    using ApiGateway.Models.Validation;
    using FluentValidation.Attributes;

    [Validator(typeof(SelectivityCalculationValidator))]
    public class SelectivityCalculation
    {
        public SelectivityCalculation(string name, IEnumerable<Ligand> ligands, IEnumerable<Receptor> receptors, decimal tolerance, decimal nanoparticleRadius, decimal nanoparticleConc, decimal glycolInterferenceParameter, decimal interchainDistance)
        {
            this.Name = name;
            this.Ligands = ligands;
            this.Receptors = receptors;
            this.Tolerance = tolerance;
            this.NanoparticleRadius = nanoparticleRadius;
            this.NanoparticleConc = nanoparticleConc;
            this.GlycolInterferenceParameter = glycolInterferenceParameter;
            this.InterchainDistance = interchainDistance;
        }

        public string Name { get; private set; }

        public IEnumerable<Ligand> Ligands { get; private set; }

        public IEnumerable<Receptor> Receptors { get; private set; }

        public decimal Tolerance { get; private set; }

        public decimal NanoparticleRadius { get; private set; }

        public decimal NanoparticleConc { get; private set; }

        public decimal GlycolInterferenceParameter { get; private set; }

        public decimal InterchainDistance { get; private set; }
    }
}

namespace ApiGateway.Documents.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ApiGateway.Models.DomainModels;
    using ApiGateway.Models.Validation;
    using FluentValidation.Attributes;

    [Validator(typeof(SelectivityCalculationValidator))]
    public class CreateSelectivityCalculationCommand : BaseCommand
    {
        public CreateSelectivityCalculationCommand(string name, IEnumerable<Ligand> ligands, IEnumerable<Receptor> receptors, decimal tolerance, decimal nanoparticleRadius, decimal nanoparticleConc, decimal glycolInterferenceParameter, decimal interchainDistance, Guid calculationID, Guid actionUserID, DateTime actionDateTime)
            : base(actionUserID, actionDateTime)
        {
            this.Name = name;
            this.Ligands = ligands;
            this.Receptors = receptors;
            this.Tolerance = tolerance;
            this.NanoparticleRadius = nanoparticleRadius;
            this.NanoparticleConc = nanoparticleConc;
            this.CalculationID = calculationID;
            this.GlycolInterferenceParameter = glycolInterferenceParameter;
            this.InterchainDistance = interchainDistance;
        }

        public string Name { get; private set; }

        public IEnumerable<Ligand> Ligands { get; private set; }

        public IEnumerable<Receptor> Receptors { get; private set; }

        public decimal Tolerance { get; private set; }

        public decimal NanoparticleRadius { get; private set; }

        public decimal NanoparticleConc { get; private set; }

        public Guid CalculationID { get; private set; }

        public decimal GlycolInterferenceParameter { get; private set; }

        public decimal InterchainDistance { get; private set; }
    }
}

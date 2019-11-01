using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Documents.Commands
{
    public class CreateSelectivityCalculationCommand : BaseCommand
    {
        public CreateSelectivityCalculationCommand(string name, Guid calculationId, IEnumerable<Ligand> ligands, IEnumerable<Receptor> receptors, decimal tolerance, decimal nanoparticleRadius, decimal nanoparticleConc, Guid actionUserId, DateTime actionDateTime)
            : base(actionUserId, actionDateTime)
        {
            this.Name = name;
            this.CalculationId = calculationId;
            this.Ligands = ligands;
            this.Receptors = receptors;
            this.Tolerance = tolerance;
            this.NanoparticleRadius = nanoparticleRadius;
            this.NanoparticleConc = nanoparticleConc;
        }

        public string Name { get; private set; }

        public Guid CalculationId { get; private set; }

        public IEnumerable<Ligand> Ligands { get; private set; }

        public IEnumerable<Receptor> Receptors { get; private set; }

        public decimal Tolerance { get; private set; }

        public decimal NanoparticleRadius { get; private set; }

        public decimal NanoparticleConc { get; private set; }
    }
}

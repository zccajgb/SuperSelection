using DomainModel.Models;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Documents.Commands
{
    public class CreateSelectivityCalculationCommand : BaseCommand, ICalculation
    {
        public CreateSelectivityCalculationCommand(string name, Guid calculationId, IEnumerable<Ligand> ligands, IEnumerable<Receptor> receptors, decimal tolerance, decimal nanoparticleRadius, decimal nanoparticleConc, decimal glycolInterferenceParameter, decimal interchainDistance, Guid actionUserId, DateTime actionDateTime)
            : base(actionUserId, actionDateTime)
        {
            this.Name = name;
            this.CalculationID = calculationId;
            this.Ligands = ligands;
            this.Receptors = receptors;
            this.Tolerance = tolerance;
            this.NanoparticleRadius = nanoparticleRadius;
            this.NanoparticleConc = nanoparticleConc;
            this.GlycolInterferenceParameter = glycolInterferenceParameter;
            this.InterchainDistance = interchainDistance;
        }

        public string Name { get; private set; }

        [BsonId]
        public Guid CalculationID { get; private set; }

        public IEnumerable<Ligand> Ligands { get; private set; }

        public IEnumerable<Receptor> Receptors { get; private set; }

        public decimal Tolerance { get; private set; }

        public decimal NanoparticleRadius { get; private set; }

        public decimal NanoparticleConc { get; private set; }

        public decimal GlycolInterferenceParameter { get; private set; }

        public decimal InterchainDistance { get; private set; }
    }
}

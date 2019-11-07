namespace DomainModel.Entities
{
    using System;
    using System.Collections.Generic;
    using DomainModel.ViewModels;
    using MongoDB.Bson.Serialization.Attributes;

    public class SelectivityCalculationsEntity
    {
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

        public IEnumerable<decimal> BindingProbability { get; private set; }

        public decimal BindingPartitionFunction { get; private set; }

        public decimal Volume { get; private set; }

        public decimal StericPotential { get; private set; }

        public decimal StericPartitionFunction { get; private set; }

        public decimal Selectivity { get; private set; }

        public Guid ActionUserID { get; private set; }

        public DateTime ActionDateTime { get; private set; }
    }
}

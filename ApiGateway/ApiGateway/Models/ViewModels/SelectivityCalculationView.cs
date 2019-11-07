namespace ApiGateway.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ApiGateway.Models.DomainModels;

    public class SelectivityCalculationView
    {
        public SelectivityCalculationView(string name, Guid calculationID, IEnumerable<Ligand> ligands, IEnumerable<Receptor> receptors, decimal tolerance, decimal nanoparticleRadius, decimal nanoparticleConc, decimal glycolInterferenceParameter, decimal interchainDistance, decimal bindingPartitionFunction, decimal volume, decimal stericPotential, decimal stericPartitionFunction, decimal selectivity, Guid actionUserID, DateTime actionDateTime)
        {
            Name = name;
            CalculationID = calculationID;
            Ligands = ligands;
            Receptors = receptors;
            Tolerance = tolerance;
            NanoparticleRadius = nanoparticleRadius;
            NanoparticleConc = nanoparticleConc;
            GlycolInterferenceParameter = glycolInterferenceParameter;
            InterchainDistance = interchainDistance;
            BindingPartitionFunction = bindingPartitionFunction;
            Volume = volume;
            StericPotential = stericPotential;
            StericPartitionFunction = stericPartitionFunction;
            Selectivity = selectivity;
            ActionUserID = actionUserID;
            ActionDateTime = actionDateTime;
        }

        public string Name { get; private set; }

        public Guid CalculationID { get; private set; }

        public IEnumerable<Ligand> Ligands { get; private set; }

        public IEnumerable<Receptor> Receptors { get; private set; }

        public decimal Tolerance { get; private set; }

        public decimal NanoparticleRadius { get; private set; }

        public decimal NanoparticleConc { get; private set; }

        public decimal GlycolInterferenceParameter { get; private set; }

        public decimal InterchainDistance { get; private set; }

        public decimal BindingPartitionFunction { get; private set; }

        public decimal Volume { get; private set; }

        public decimal StericPotential { get; private set; }

        public decimal StericPartitionFunction { get; private set; }

        public decimal Selectivity { get; private set; }

        public Guid ActionUserID { get; private set; }

        public DateTime ActionDateTime { get; private set; }
    }
}

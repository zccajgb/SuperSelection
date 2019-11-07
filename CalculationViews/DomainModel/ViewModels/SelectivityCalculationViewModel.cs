namespace DomainModel.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MongoDB.Bson.Serialization.Attributes;

    public class SelectivityCalculationViewModel : ICalculationViewModel
    {
        public SelectivityCalculationViewModel(string name, string calculationID, IEnumerable<Ligand> ligands, IEnumerable<Receptor> receptors, decimal tolerance, decimal nanoparticleRadius, decimal nanoparticleConc, decimal glycolInterferenceParameter, decimal interchainDistance, IEnumerable<decimal> bindingProbability, decimal bindingPartitionFunction, decimal volume, decimal stericPotential, decimal stericPartitionFunction, decimal selectivity, string actionUserID, DateTime actionDateTime)
        {
            this.Name = name;
            this.CalculationID = new Guid(calculationID);
            this.Ligands = ligands;
            this.Receptors = receptors;
            this.Tolerance = tolerance;
            this.NanoparticleRadius = nanoparticleRadius;
            this.NanoparticleConc = nanoparticleConc;
            this.GlycolInterferenceParameter = glycolInterferenceParameter;
            this.InterchainDistance = interchainDistance;
            this.BindingPartitionFunction = bindingPartitionFunction;
            this.Volume = volume;
            this.StericPotential = stericPotential;
            this.StericPartitionFunction = stericPartitionFunction;
            this.Selectivity = selectivity;
            this.ActionUserID = new Guid(actionUserID);
            this.ActionDateTime = actionDateTime;

            this.SetBindingProbability(bindingProbability);
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

        public void SetBindingProbability(IEnumerable<decimal> bindingProbability)
        {
            var ligandBindingProbablities = bindingProbability.Take(this.Ligands.Count());
            var receptorBindingProbablities = bindingProbability.Skip(this.Ligands.Count());

            foreach ((var ligand, var bindingProb) in this.Ligands.Zip(ligandBindingProbablities, (ligand, bindingProb) => (ligand, bindingProb)))
            {
                ligand.BindingProbability = bindingProb;
            }

            foreach ((var receptor, var bindingProb) in this.Receptors.Zip(receptorBindingProbablities, (receptor, bindingProb) => (receptor, bindingProb)))
            {
                receptor.BindingProbability = bindingProb;
            }
        }
    }
}

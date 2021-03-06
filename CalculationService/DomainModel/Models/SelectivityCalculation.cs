﻿namespace DomainModel.Models
{
    using System;
    using System.Linq;
    using DomainModel.Documents.Commands;

    public class SelectivityCalculation
    {
        public SelectivityCalculation(CreateSelectivityCalculationCommand cmd)
        {
            this.Name = cmd.Name;
            this.ActionUserID = cmd.ActionUserId;
            this.ActionDateTime = cmd.ActionDateTime;

            this.CalculationID = cmd.CalculationID;
            this.Tolerance = cmd.Tolerance;
            this.NanoparticleRadius = cmd.NanoparticleRadius;
            this.NanoparticleConc = cmd.NanoparticleConc;
            this.InterchainDistance = cmd.InterchainDistance;
            this.GlycolInterferenceParameter = cmd.GlycolInterferenceParameter;

            this.N = cmd.Ligands.Select(x => x.NumberOfLigands)
                    .Concat(cmd.Receptors.Select(x => x.NumberOfReceptors)).ToArray();

            this.InitialProbability = cmd.Ligands.Select(x => x.InitialProbability)
                    .Concat(cmd.Receptors.Select(x => x.InitialProbability)).ToArray();

            this.TetherLength = cmd.Ligands.Select(x => x.TetherLength).ToArray();

            this.Chi = this.CreateChi(cmd);
        }

        public string Name { get; private set; }

        public Guid ActionUserID { get; private set; }

        public DateTime ActionDateTime { get; private set; }

        public Guid CalculationID { get; private set; }

        public decimal[][] Chi { get; private set; }

        public int[] N { get; private set; }

        public decimal[] InitialProbability { get; private set; }

        public decimal Tolerance { get; private set; }

        public decimal[] TetherLength { get; private set; }

        public decimal NanoparticleRadius { get; private set; }

        public decimal NanoparticleConc { get; private set; }

        public decimal InterchainDistance { get; private set; }

        public decimal GlycolInterferenceParameter { get; private set; }

        public decimal[][] CreateChi(CreateSelectivityCalculationCommand cmd)
        {
            var top = cmd.Ligands
                .Select(x => cmd.Ligands.Select(y => 0m)
                    .Concat(x.SingleBondStrength)
                    .ToArray());

            var receptorBondStrength = cmd.Ligands
                .SelectMany(x => x.SingleBondStrength.Select((item, ind) => (item, ind)))
                .GroupBy(x => x.ind, x => x.item)
                .Select(x => x.ToArray());

            var bottom = receptorBondStrength
                .Select(x => x
                    .Concat(cmd.Receptors.Select(y => 0m))
                    .ToArray());

            return top.Concat(bottom).ToArray();
        }
    }
}

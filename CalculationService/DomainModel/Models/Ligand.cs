namespace DomainModel.Models
{
    using System.Collections.Generic;

    public class Ligand
    {
        public Ligand(decimal tetherLength, int numberOfLigands, decimal initialProbability, IEnumerable<decimal> singleBondStrength)
        {
            this.TetherLength = tetherLength;
            this.NumberOfLigands = numberOfLigands;
            this.InitialProbability = initialProbability;
            this.SingleBondStrength = singleBondStrength;
        }

        public decimal TetherLength { get; set; }

        public int NumberOfLigands { get; set; }

        public decimal InitialProbability { get; set; }

        public IEnumerable<decimal> SingleBondStrength { get; set; }
    }
}

namespace DomainModel.ViewModels
{
    using System.Collections.Generic;

    public class Ligand
    {
        public Ligand(decimal tetherLength, int numberOfLigands, decimal initialProbability, IEnumerable<decimal> singleBondStrength, decimal bindingProbability)
        {
            this.TetherLength = tetherLength;
            this.NumberOfLigands = numberOfLigands;
            this.InitialProbability = initialProbability;
            this.SingleBondStrength = singleBondStrength;
            this.BindingProbability = bindingProbability;
        }

        public decimal TetherLength { get; set; }

        public int NumberOfLigands { get; set; }

        public decimal InitialProbability { get; set; }

        public IEnumerable<decimal> SingleBondStrength { get; set; }

        public decimal BindingProbability { get; set; }
    }
}

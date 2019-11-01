namespace DomainModel.Models
{
    using System.Collections.Generic;

    public class Receptor
    {
        public Receptor(int numberOfReceptors, decimal initialProbability)
        {
            this.NumberOfReceptors = numberOfReceptors;
            this.InitialProbability = initialProbability;
        }

        public int NumberOfReceptors { get; set; }

        public decimal InitialProbability { get; set; }
    }
}

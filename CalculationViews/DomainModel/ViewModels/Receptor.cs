namespace DomainModel.ViewModels
{
    public class Receptor
    {
        public Receptor(int numberOfReceptors, decimal bindingProbability, decimal initialProbability)
        {
            this.NumberOfReceptors = numberOfReceptors;
            this.BindingProbability = bindingProbability;
            this.InitialProbability = initialProbability;
        }

        public int NumberOfReceptors { get; set; }

        public decimal BindingProbability { get; set; }

        public decimal InitialProbability { get; set; }
    }
}
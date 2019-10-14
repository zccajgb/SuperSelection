using System;

namespace DomainModel
{
    public class CalculationsOrchestrator
    {
        private readonly CalculationsRepository calculationsRepository;

        public CalculationsOrchestrator(CalculationsRepository calculationsRepository)
        {
            this.calculationsRepository = calculationsRepository;
        }
        
        public void ProcessCalculation()
        {

        }
    }
}

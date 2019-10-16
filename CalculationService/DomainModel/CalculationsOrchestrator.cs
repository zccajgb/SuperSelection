using DomainModel.Documents.Commands;
using DomainModel.Repos;
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
        
        public string ProcessCalculation(object cmd)
        {
            switch (cmd)
            {
                case CreateSelectivityAndActivityCalculationCommand c:
                    return this.calculationsRepository.CreateSelectivityAndActivityCalculation(c);
                default:
                    throw new ArgumentException("Command is not a recognied type");
            }

        }
    }
}

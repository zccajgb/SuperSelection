using DomainModel.Documents.Commands;
using DomainModel.Repos;
using Serilog;
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
        
        public void ProcessCalculation(object cmd)
        {
            switch (cmd)
            {
                case CreateSelectivityAndActivityCalculationCommand c:
                    Log.Logger.Information("Calculation of type CreateSelectivityAndActivityCommand");
                    this.calculationsRepository.CreateSelectivityAndActivityCalculation(c);
                    break;
                default:
                    Log.Logger.Information("Command is not recognised type: {@cmd}", cmd);
                    throw new ArgumentException("Command is not a recognied type");
            }

        }
    }
}

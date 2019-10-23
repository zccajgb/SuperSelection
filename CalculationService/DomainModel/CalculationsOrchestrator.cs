namespace DomainModel
{
    using System;
    using DomainModel.Documents.Commands;
    using DomainModel.Repos;
    using Serilog;

    public class CalculationsOrchestrator : ICalculationsOrchestrator
    {
        private readonly ICalculationsRepository calculationsRepository;

        public CalculationsOrchestrator(ICalculationsRepository calculationsRepository)
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
                    Log.Logger.Error("Command is not recognised: {@cmd}", cmd);
                    throw new ArgumentException("Command is not recognised");
            }
        }
    }
}

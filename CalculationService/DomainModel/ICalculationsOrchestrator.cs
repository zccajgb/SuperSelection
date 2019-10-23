namespace DomainModel
{
    public interface ICalculationsOrchestrator
    {
        void ProcessCalculation(object cmd);
    }
}
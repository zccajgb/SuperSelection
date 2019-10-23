namespace DomainModel.Repos
{
    using DomainModel.Documents.Commands;

    public interface ICalculationsRepository
    {
        void CreateSelectivityAndActivityCalculation(CreateSelectivityAndActivityCalculationCommand cmd);
    }
}
namespace DomainModel.Repos
{
    using DomainModel.Documents.Commands;

    public interface ICalculationsRepository
    {
        void CreateSelectivityCalculation(CreateSelectivityCalculationCommand cmd);
    }
}
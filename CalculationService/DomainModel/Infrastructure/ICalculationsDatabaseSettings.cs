namespace DomainModel.Infrastructure
{
    public interface ICalculationsDatabaseSettings
    {
        string CalculationsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
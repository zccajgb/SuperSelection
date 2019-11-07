namespace DomainModel.Infrastructure
{
    public class CalculationsDatabaseSettings : ICalculationsDatabaseSettings
    {
        public string CalculationsCollectionName { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}

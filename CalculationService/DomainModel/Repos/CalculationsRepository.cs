namespace DomainModel.Repos
{
    using System.Collections.Generic;
    using System.Text;
    using DomainModel.Documents.Commands;
    using DomainModel.Infrastructure;
    using DomainModel.Models;
    using MongoDB.Driver;
    using Newtonsoft.Json;
    using RabbitMQ.Client;
    using Serilog;

    public class CalculationsRepository : ICalculationsRepository
    {
        private readonly IMongoCollection<ICalculation> calculations;
        private readonly ConnectionFactory connectionFactory;

        public CalculationsRepository(RabbitMQConnectionHelper connectionHelper, CalculationsDatabaseSettings settings)
        {
            this.connectionFactory = connectionHelper.ConnectionFactory;

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            this.calculations = database.GetCollection<ICalculation>(settings.CalculationsCollectionName);
        }

        public void CreateSelectivityCalculation(CreateSelectivityCalculationCommand cmd)
        {
            this.calculations.InsertOne(cmd);
            var calculation = new SelectivityCalculation(cmd);

            using (var connection = this.connectionFactory.CreateConnection())
            {
                Log.Logger.Information("Connectiong to RabbitMQ established");
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "Selectivity", durable: false, exclusive: false, autoDelete: false, arguments: null);
                    channel.QueueDeclare(queue: "test", durable: false, exclusive: false, autoDelete: false, arguments: null);
                    var json = JsonConvert.SerializeObject(calculation);
                    var body = Encoding.UTF8.GetBytes(json);

                    channel.BasicPublish(exchange: string.Empty, routingKey: "Selectivity", basicProperties: null, body: body);
                    Log.Logger.Information("Command published to RabbitMQ: {@cmd}", calculation );
                }
            }
        }
    }
}
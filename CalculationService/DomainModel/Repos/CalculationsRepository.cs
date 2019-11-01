namespace DomainModel.Repos
{
    using System.Collections.Generic;
    using System.Text;
    using DomainModel.Documents.Commands;
    using DomainModel.Infrastructure;
    using DomainModel.Models;
    using Newtonsoft.Json;
    using RabbitMQ.Client;
    using Serilog;

    public class CalculationsRepository : ICalculationsRepository
    {
        private readonly ConnectionFactory connectionFactory;

        public CalculationsRepository(RabbitMQConnectionHelper connectionHelper)
        {
            this.connectionFactory = connectionHelper.ConnectionFactory;
        }

        public void CreateSelectivityCalculation(CreateSelectivityCalculationCommand cmd)
        {
            var ligands = new List<Ligand>()
            {
                new Ligand(1e-9m, 1, 0.5m, new List<decimal>() { 1m, 2m, 3m }),
                new Ligand(1e-9m, 1, 0.5m, new List<decimal>() { 4m, 5m, 6m }),
                new Ligand(1e-9m, 1, 0.5m, new List<decimal>() { 7m, 8m, 9m }),
            };

            var receptors = new List<Receptor>()
            {
                new Receptor(1, 0.5m),
                new Receptor(1, 0.5m),
                new Receptor(1, 0.5m),
            };

            cmd = new CreateSelectivityCalculationCommand("test", default, ligands, receptors, 0.001m, 50e-9m, 1m, default, default);
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
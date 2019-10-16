using System;
using System.Text;
using DomainModel.Documents.Commands;
using DomainModel.Infrastructure;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace DomainModel.Repos
{
    public class CalculationsRepository
    {
        private ConnectionFactory connectionFactory;

        public CalculationsRepository(RabbitMQConnectionHelper connectionHelper)
        {
            this.connectionFactory = connectionHelper.ConnectionFactory;
        }
        public string CreateSelectivityAndActivityCalculation(CreateSelectivityAndActivityCalculationCommand cmd)
        {
            using(var connection = connectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "SelectivityAndActivityCalculations", durable: false, exclusive: false, autoDelete: false, arguments: null);
                    channel.QueueDeclare(queue: "test", durable: false, exclusive: false, autoDelete: false, arguments: null);
                    var json = CommandBuilder.BuildJson(cmd);
                    var body = Encoding.UTF8.GetBytes(json);

                    body = Encoding.UTF8.GetBytes("hello World");

                    channel.BasicPublish(exchange: "", routingKey: "SelectivityAndActivityCalculations", basicProperties: null, body: body);
                    channel.BasicPublish(exchange: "", routingKey: "test", basicProperties: null, body: body);
                }
            }
            return "hello world";
        }
    }
}
﻿using System;
using System.Text;
using DomainModel.Documents.Commands;
using DomainModel.Infrastructure;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;

namespace DomainModel.Repos
{
    public class CalculationsRepository
    {
        private readonly ConnectionFactory connectionFactory;

        public CalculationsRepository(RabbitMQConnectionHelper connectionHelper)
        {
            this.connectionFactory = connectionHelper.ConnectionFactory;
        }
        public void CreateSelectivityAndActivityCalculation(CreateSelectivityAndActivityCalculationCommand cmd)
        {
            using(var connection = connectionFactory.CreateConnection())
            {
                Log.Logger.Information("Connectiong to RabbitMQ established");
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "SelectivityAndActivityCalculations", durable: false, exclusive: false, autoDelete: false, arguments: null);
                    channel.QueueDeclare(queue: "test", durable: false, exclusive: false, autoDelete: false, arguments: null);
                    var json = CommandBuilder.BuildJson(cmd);
                    var body = Encoding.UTF8.GetBytes(json);

                    channel.BasicPublish(exchange: "", routingKey: "SelectivityAndActivityCalculations", basicProperties: null, body: body);
                    Log.Logger.Information("Command published to RabbitMQ: {@cmd}", cmd);
                }
            }
        }
    }
}
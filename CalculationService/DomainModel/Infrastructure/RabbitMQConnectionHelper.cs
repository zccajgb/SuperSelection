using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Infrastructure
{
    public class RabbitMQConnectionHelper
    {
        public RabbitMQConnectionHelper(ConnectionFactory connectionFactory, string hostName, string userName, string password)
        {
            this.ConnectionFactory = connectionFactory;
            connectionFactory.HostName = hostName;
            connectionFactory.UserName = userName;
            connectionFactory.Password = password;
        }

        public ConnectionFactory ConnectionFactory { get; }
    }
}

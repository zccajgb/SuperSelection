namespace DomainModel.Infrastructure
{
    using RabbitMQ.Client;

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

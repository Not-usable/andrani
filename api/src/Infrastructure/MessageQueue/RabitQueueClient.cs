using RabbitMQ.Client;
using System.Text;

namespace Infrastructure.MessageQueue
{
    public class RabitQueueClient : IQueueClient
    {
        public void Send(int id)
        {
            var factory = new ConnectionFactory() { HostName = "my-rabbit" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "geo-queue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var body = Encoding.UTF8.GetBytes(id.ToString());

            channel.BasicPublish(exchange: "",
                                 routingKey: "geo-queue",
                                 basicProperties: null,
                                 body: body);
        }
    }
}

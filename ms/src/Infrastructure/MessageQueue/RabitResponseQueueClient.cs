using Domain.Entities;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using Application.Interfaces.Services;
using Application.Interfaces.MessageQueue;

namespace Infrastructure.MessageQueue
{
    public class RabitResponseQueueClient : IResponseQueueClient
    {
        public void Send(GeoResponseMessage request)
        {
            var factory = new ConnectionFactory() { HostName = "my-rabbit" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "geo-queue-response",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(request));

            channel.BasicPublish(exchange: "",
                                 routingKey: "geo-queue-response",
                                 basicProperties: null,
                                 body: body);
        }
    }
}

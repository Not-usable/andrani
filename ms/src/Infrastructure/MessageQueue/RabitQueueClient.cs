using Domain.Entities;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using Application.Interfaces.Services;
using Application.Interfaces.MessageQueue;

namespace Infrastructure.MessageQueue
{
    public class RabitQueueClient : IQueueClient
    {
        public void Send(GeoRequest request)
        {
            var factory = new ConnectionFactory() { HostName = "my-rabbit" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "geo-queue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var req = new GeoRequestMessage()
            {
                Id = request.Id,
                City = request.City,
                Street = request.Street,
                PostalCode = request.PostalCode,
                Number = request.Number,
                State = request.Province,
                Country = request.State
            };

            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(req));

            channel.BasicPublish(exchange: "",
                                 routingKey: "geo-queue",
                                 basicProperties: null,
                                 body: body);
        }
    }
}

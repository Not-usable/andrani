using Application.Features.GeoRequest.Commands;
using Application.Interfaces.MessageQueue;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Andreani.QueueAdapters
{
    public class GeoReceiverResponse : BackgroundService
    {
        private IModel _channel;
        private IConnection _connection;
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public GeoReceiverResponse(ILogger<GeoReceiverResponse> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
            InitializeRabbitMqListener();
        }

        private void InitializeRabbitMqListener()
        {
            var factory = new ConnectionFactory
            {
                HostName = "my-rabbit"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "geo-queue-response", durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());

                _logger.LogWarning("received-response: " + content);

                //var updateCustomerFullNameModel = JsonConvert.DeserializeObject<UpdateCustomerFullNameModel>(content);
                var req = JsonSerializer.Deserialize<UpdateCoordinatesGeoRequestCommand>(content);

                await _mediator.Send(req);

                //HandleMessage(updateCustomerFullNameModel);

                _channel.BasicAck(ea.DeliveryTag, false);
            };

            _channel.BasicConsume("geo-queue-response", false, consumer);

            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}

using Application.Interfaces.MessageQueue;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Infrastructure.MessageQueue;
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
    public class GeoReceiver : BackgroundService
    {
        private IModel _channel;
        private IConnection _connection;
        private readonly ILogger _logger;
        private readonly IGeoService _service;
        private readonly IResponseQueueClient _responseQueue;

        public GeoReceiver(ILogger<GeoReceiver> logger, IGeoService service, IResponseQueueClient responseQueue)
        {
            _logger = logger;
            _service = service;
            _responseQueue = responseQueue;
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
            _channel.QueueDeclare(queue: "geo-queue", durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());

                _logger.LogWarning("received: " + content);

                //var updateCustomerFullNameModel = JsonConvert.DeserializeObject<UpdateCustomerFullNameModel>(content);
                var req = JsonSerializer.Deserialize<GeoRequestMessage>(content);

                var res = await _service.CompleteCoordinatesAsync(req);

                //_repository.Update(res);
                _logger.LogWarning(JsonSerializer.Serialize(res));

                _responseQueue.Send(res);
                //HandleMessage(updateCustomerFullNameModel);

                _channel.BasicAck(ea.DeliveryTag, false);
            };

            _channel.BasicConsume("geo-queue", false, consumer);

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

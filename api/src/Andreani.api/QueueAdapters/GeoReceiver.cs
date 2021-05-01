using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Andreani.QueueAdapters
{
    public class GeoReceiver : BackgroundService
    {
        private IModel _channel;
        private IConnection _connection;
        private readonly ILogger _logger;

        public GeoReceiver(ILogger<GeoReceiver> logger)
        {
            _logger = logger;
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
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());

                _logger.LogWarning("received: " + content);

                    //var updateCustomerFullNameModel = JsonConvert.DeserializeObject<UpdateCustomerFullNameModel>(content);
                    int toGeo = int.Parse(content);
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

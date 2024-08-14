using JobFreela.Core.Events;
using JobFreela.Core.Repositories;
using JobFreela.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace JobFreela.Application.Consumers;

public class PaymentApprovedConsumer : BackgroundService
{
    private const string PAYMENT_APPROVED_QUEUE = "payment.approved";
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly IServiceProvider _provider;
    public PaymentApprovedConsumer(IServiceProvider provider)
    {
        _provider = provider;

        var factory = new ConnectionFactory
        {
            HostName = "localhost"
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.QueueDeclare(
            queue: PAYMENT_APPROVED_QUEUE,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);
    }
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (sender, eventArgs) =>
        {
            var paymentApprovedBytes = eventArgs.Body.ToArray();
            var paymentApprovedJson = Encoding.UTF8.GetString(paymentApprovedBytes);

            var paymentApprovedEvent = JsonSerializer.Deserialize<PaymentApprovedIntegrationEvent>(paymentApprovedJson);

            FinishProject(paymentApprovedEvent.IdProject);

            _channel.BasicAck(eventArgs.DeliveryTag, false);
        };

        _channel.BasicConsume(PAYMENT_APPROVED_QUEUE, false, consumer);

        return Task.CompletedTask;
    }

    public async Task FinishProject(int id)
    {
        using (var scope = _provider.CreateScope())
        {
            var repository = scope.ServiceProvider.GetRequiredService<IProjectRepository>();

            var project = await repository.GetByIdAsync(id);
            project.Finish();

            await repository.SaveChangesAsync();
        }
    }
}

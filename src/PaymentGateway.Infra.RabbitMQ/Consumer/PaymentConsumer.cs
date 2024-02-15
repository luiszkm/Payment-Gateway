using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using PaymentGateway.Domain.Enums;

namespace PaymentGateway.Infra.RabbitMQ.Consumer;
public class PaymentConsumer : BackgroundService
{
    private readonly IConnection _connection;
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<PaymentConsumer> _logger;
    private readonly IConfiguration _configuration;
    private readonly ChannelFactory _channelFactory;

    public PaymentConsumer(
        IServiceProvider serviceProvider,
        IConnection connection,
        ILogger<PaymentConsumer> logger,
        IConfiguration configuration,
        ChannelFactory factory
        )
    {
        _serviceProvider = serviceProvider;
        _connection = connection;
        _logger = logger;
        _configuration = configuration;
        _channelFactory = factory;



    }


    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var routingKey = _configuration["RabbitMQ:QueueNameProcess"];
        var routingKeyFailed = _configuration["RabbitMQ:QueueNameFailed"];
        try
        {
            _channelFactory.CreateConsumerChannel(routingKeyFailed);
            var _channel = _channelFactory.CreateConsumerChannel(routingKey);
            if (!_connection.IsOpen)
            {
                throw new InvalidOperationException("Cannot create channel because the connection is closed.");
            }

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (sender, eventArgs) =>
            {
                var body = eventArgs.Body;
                var paymentApprovedJson = Encoding.UTF8.GetString(body.ToArray());
                var paymentInfo = JsonSerializer.Deserialize<CreditCardPayment>(paymentApprovedJson);

                //ProcessPaymentResponse(paymentInfo);

                var payment = SavePaymentData(paymentInfo);


                var paymentApproved = JsonSerializer.Serialize(payment);
                var paymentApprovedBytes = Encoding.UTF8.GetBytes(paymentApproved);

                if (payment.Status == PaymentStatusEnum.Processed)
                {
                    _channelFactory.PublishMessage(paymentApprovedBytes, routingKey);
                }
                else
                {
                    _channelFactory.PublishMessage(paymentApprovedBytes, routingKeyFailed);

                }

                _logger.LogInformation("Payment processed: {PaymentId}", paymentInfo.Id);
                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _channel.BasicConsume(_configuration["RabbitMQ:QueueName"], false, consumer);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while consuming messages.");
        }

        return Task.CompletedTask;
    }

    public void ProcessPaymentResponse(CreditCardPayment paymentInfo)
    {
        // Enviar a resposta para o serviço de pagamento

        using var scope = _serviceProvider.CreateScope();
        var paymentService = scope.ServiceProvider.GetRequiredService<IPaymentService>();
        paymentService.ProcessPayment(paymentInfo);
    }

    public Payment SavePaymentData(CreditCardPayment paymentInfo)
    {
        var payment = new Payment(
            paymentInfo.Amount);

        var getRadomBool = new Random().Next(0, 2) == 1;

        if (getRadomBool)
        {
            payment.MarkAsProcessed();
        }
        else
        {
            payment.MarkAsFailed();
        }


        return payment;

    }


}

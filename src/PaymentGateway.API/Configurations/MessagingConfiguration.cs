using Microsoft.Extensions.Options;
using PaymentGateway.Domain.Interfaces;
using PaymentGateway.Infra.RabbitMQ.Configurations;
using PaymentGateway.Infra.RabbitMQ.Consumer;
using PaymentGateway.Infra.RabbitMQ.Producer;
using PaymentGateway.Infra.Services;
using RabbitMQ.Client;

namespace PaymentGateway.API.Configurations;

public static class MessagingConfiguration
{

    public static IServiceCollection AddRabbitMQ(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.Configure<RabbitMQConfiguration>(configuration.GetSection("RabbitMQ"));

        services.AddSingleton<IConnection>(sp =>
        {
            var config = sp.GetRequiredService<IOptions<RabbitMQConfiguration>>().Value;
            var factory = new ConnectionFactory
            {
                HostName = config.Hostname,
                Port = config.Port,
                UserName = config.Username,
                Password = config.Password

            };
            return factory.CreateConnection();
        });


        services.AddSingleton<ChannelFactory>();

        services.AddScoped<IPaymentService, PaymentService>();

        services.AddMessageProducer();

        services.AddMessageConsumer();

        return services;

    }


    public static IServiceCollection AddMessageProducer(
        this IServiceCollection services
    )
    {
        services.AddTransient<IMessageProducer, RabbitMQProducer>();
        return services;
    }

    public static IServiceCollection AddMessageConsumer(
        this IServiceCollection services
    )
    {
        services.AddHostedService<PaymentConsumer>();

        return services;
    }

}
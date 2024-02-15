using Microsoft.Extensions.Options;
using PaymentGateway.Domain.Interfaces;
using PaymentGateway.Infra.RabbitMQ.Configurations;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace PaymentGateway.Infra.RabbitMQ.Producer
{
    public class RabbitMQProducer : IMessageProducer
    {
        private readonly ChannelFactory _channelFactory;
        private readonly IConfiguration _config;

        public RabbitMQProducer(
            ChannelFactory channelFactory,
            IConfiguration config)
        {
            _channelFactory = channelFactory;
            _config = config;
        }


        public Task SendMessageAsync(byte[] message)
        {

            _channelFactory.PublishMessage(body: message, _config["RabbitMQ:QueueName"]);

            return Task.CompletedTask;

        }
    }

}
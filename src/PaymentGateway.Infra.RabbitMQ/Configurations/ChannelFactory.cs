using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;

public class ChannelFactory : IDisposable
{
    private readonly IConnection _connection;
    private bool _disposed = false;

    public ChannelFactory(IConnection connection, IConfiguration configuration)
    {
        _connection = connection ?? throw new ArgumentNullException(nameof(connection));
    }

    public void PublishMessage(byte[] body, string routingKey)
    {

        using (var channel = CreateConsumerChannel(routingKey))
        {
            channel.BasicPublish(
                exchange: "",
                routingKey: routingKey,
                basicProperties: null,
                body: body);
        }
    }

    public IModel CreateConsumerChannel(string queueName)
    {
        if (!_connection.IsOpen)
        {
            throw new InvalidOperationException("Cannot create channel because the connection is closed.");
        }
        var channel = _connection.CreateModel();
        channel.QueueDeclare(
            queue: queueName,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);
        return channel;
    }

    // Implementação do IDisposable para liberar os recursos
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // Liberar recursos gerenciados
                _connection?.Dispose();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
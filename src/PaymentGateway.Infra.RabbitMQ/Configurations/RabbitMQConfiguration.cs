﻿namespace PaymentGateway.Infra.RabbitMQ.Configurations;
public class RabbitMQConfiguration
{
    public const string ConfigurationSection = "RabbitMQ";
    public string? Hostname { get; set; }
    public int Port { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }

}

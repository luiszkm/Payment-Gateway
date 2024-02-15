using PaymentGateway.Application.UseCases;

namespace PaymentGateway.API.Configurations;

public static class ConnectionsConfigurations
{
    public static IServiceCollection AddAppConnections(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddUseCases();
        return services;
    }
    public static IServiceCollection AddUseCases(
        this IServiceCollection services)
    {

        services.AddScoped<IProcessPayment, ProcessPayment>();

        return services;

    }





}

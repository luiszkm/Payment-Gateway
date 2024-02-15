using System.Text;
using System.Text.Json;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.Interfaces;

namespace PaymentGateway.Infra.Services;
public class PaymentService : IPaymentService
{
    private readonly IMessageProducer _messageBusService;
    public PaymentService(IMessageProducer messageBusService)
    {
        _messageBusService = messageBusService;
    }

    public void ProcessPaymentMethod(CreditCardPayment paymentRequest)
    {
        var paymentRequestJson = JsonSerializer.Serialize(paymentRequest);
        var paymentRequestBytes = Encoding.UTF8.GetBytes(paymentRequestJson);

        _messageBusService.SendMessageAsync(paymentRequestBytes);
    }

    public void ProcessPayment(CreditCardPayment paymentRequest)
    {
        var paymentRequestJson = JsonSerializer.Serialize(paymentRequest);
        var paymentRequestBytes = Encoding.UTF8.GetBytes(paymentRequestJson);

        _messageBusService.SendMessageAsync(paymentRequestBytes);

    }
}

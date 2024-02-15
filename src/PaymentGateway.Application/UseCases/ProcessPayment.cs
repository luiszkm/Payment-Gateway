using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.Interfaces;

namespace PaymentGateway.Application.UseCases;

public class ProcessPayment : IProcessPayment
{
    private readonly IPaymentService _messageProducer;

    public ProcessPayment(IPaymentService messageProducer)
    {
        _messageProducer = messageProducer;
    }
    public ProcessPaymentOutput Execute(ProcessPaymentInput input)
    {
        var creditCardPayment = new CreditCardPayment(
                       input.CardNumber,
                                  input.CardHolderName,
                                  input.ExpiryDate,
                                  input.Cvv,
                                  input.Amount

                              );
        _messageProducer.ProcessPaymentMethod(creditCardPayment);

        return new ProcessPaymentOutput(true, "Payment processed successfully", Guid.NewGuid());


    }
}


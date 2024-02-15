using PaymentGateway.Domain.Entities;

namespace PaymentGateway.Domain.Interfaces;
public interface IStripeService
{
    void ReceivePaymentCreditCard(CreditCardPayment creditCard);
}

using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.Interfaces;

namespace PaymentGateway.Infra.Stripe.Service;
internal class StripeService : IStripeService
{
    public void ReceivePaymentCreditCard(CreditCardPayment creditCard)
    {
        throw new NotImplementedException();
    }
}

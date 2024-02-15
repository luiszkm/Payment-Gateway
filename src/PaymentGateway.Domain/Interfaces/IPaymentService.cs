using PaymentGateway.Domain.Entities;

namespace PaymentGateway.Domain.Interfaces;
public interface IPaymentService
{
    void ProcessPaymentMethod(CreditCardPayment paymentRequest);

    void ProcessPayment(CreditCardPayment paymentInfo);

}

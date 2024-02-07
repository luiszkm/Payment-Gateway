

using PaymentGateway.Domain.SeedWoork;
using PaymentGateway.Domain.Validations;

namespace PaymentGateway.Domain.Entities;
public class CreditCardPayment : AggregateRoot
{
    public CreditCardPayment(
        string cardNumber,
        string cardHolderName,
        DateTime expiryDate,
        string cvv,
        decimal amount)
    {
        CardNumber = cardNumber;
        CardHolderName = cardHolderName;
        ExpiryDate = expiryDate;
        Cvv = cvv;
        Amount = amount;

        Validate();
    }

    public string CardNumber { get; set; }
    public string CardHolderName { get; set; }
    public DateTime ExpiryDate { get; set; }
    public string Cvv { get; set; }
    public decimal Amount { get; set; }

    public void Validate()
    {
        CreditCardPaymentValidation.ValidateCreditCardPayment(this);
    }
}

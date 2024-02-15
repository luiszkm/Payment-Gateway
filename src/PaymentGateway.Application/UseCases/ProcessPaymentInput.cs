

namespace PaymentGateway.Application.UseCases;
public class ProcessPaymentInput
{
    public ProcessPaymentInput(
        string cardNumber,
        string cardHolderName,
        string expiryDate,
        string cvv,
        decimal amount,
        Guid orderId,
        Guid clientId)
    {
        CardNumber = cardNumber;
        CardHolderName = cardHolderName;
        ExpiryDate = expiryDate;
        Cvv = cvv;
        Amount = amount;
        OrderId = orderId;
        ClientId = clientId;
    }


    public string CardNumber { get; set; }
    public string CardHolderName { get; set; }
    public string ExpiryDate { get; set; }
    public string Cvv { get; set; }
    public decimal Amount { get; set; }
    public Guid OrderId { get; set; }
    public Guid ClientId { get; set; }


}

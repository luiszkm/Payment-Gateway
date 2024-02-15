

using PaymentGateway.Domain.Enums;
using PaymentGateway.Domain.SeedWoork;
using PaymentGateway.Domain.Validations;

namespace PaymentGateway.Domain.Entities;
public class Payment : AggregateRoot
{
    public Payment(
        // Guid orderId,
        // Guid transactionId,
        // Guid clientId,
        decimal amount)
    {
        // OrderId = orderId;
        // TransactionId = transactionId;
        // ClientId = clientId;
        Amount = amount;
        Status = PaymentStatusEnum.Pending;

        //Validate();
    }

    // public Guid OrderId { get; private set; }
    // public Guid TransactionId { get; private set; }
    // public Guid ClientId { get; private set; }
    public decimal Amount { get; private set; }
    public PaymentStatusEnum Status { get; private set; }


    public void MarkAsProcessed()
    {
        Status = PaymentStatusEnum.Processed;
    }
    public void MarkAsFailed()
    {
        Status = PaymentStatusEnum.Failed;
    }

    public void Validate()
    {
        // PaymentValidation.ValidateDecimal(this.Amount, nameof(this.Amount));
        // PaymentValidation.ValidateId(this.OrderId);
        // PaymentValidation.ValidateId(this.TransactionId);
        // PaymentValidation.ValidateId(this.ClientId);

    }

}

namespace PaymentGateway.Application.UseCases;
public class ProcessPaymentOutput
{

    public ProcessPaymentOutput(
        bool isSuccessful,
        string message,
        Guid paymentId)
    {
        IsSuccessful = isSuccessful;
        Message = message;
        PaymentId = paymentId;
    }

    public bool IsSuccessful { get; set; }
    public string Message { get; set; }
    public Guid PaymentId { get; set; }
}

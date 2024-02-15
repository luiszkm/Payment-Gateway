namespace PaymentGateway.Application.UseCases;
public interface IProcessPayment
{
    ProcessPaymentOutput Execute(ProcessPaymentInput input);
}

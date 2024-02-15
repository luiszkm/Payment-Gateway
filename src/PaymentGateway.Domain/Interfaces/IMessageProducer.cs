namespace PaymentGateway.Domain.Interfaces;
public interface IMessageProducer
{
    Task SendMessageAsync(byte[] message);

}

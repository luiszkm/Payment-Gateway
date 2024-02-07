

namespace PaymentGateway.Domain.SeedWoork;
public abstract class Entity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
    }




}

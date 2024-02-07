
using Bogus.DataSets;

namespace PaymentGateway.UnitTests.Domain.Common;
public class BaseFixture
{
    public Faker Faker { get; set; }

    public BaseFixture()
        => Faker = new Faker("pt_BR");
    public Decimal GetRandomDecimal()
        => new Random().Next(2, 10000);

    public Guid GetValidGuid()
        => Guid.NewGuid();

    public string GerValidCardNumber()
        => Faker.Finance.CreditCardNumber(CardType.Mastercard);

    public string GetValidCardHolderName()
    => Faker.Person.FullName;

    public string GetValidCvv()
        => Faker.Finance.CreditCardCvv();

    public DateTime GetValidExpiryDate()
    => Faker.Date.Future();

    public DomainEntity.CreditCardPayment GetValidCreditCardPayment()
        => new DomainEntity.CreditCardPayment(
            GerValidCardNumber(),
            GetValidCardHolderName(),
            GetValidExpiryDate(),
            GetValidCvv(),
            GetRandomDecimal());
}

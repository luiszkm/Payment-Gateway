

namespace PaymentGateway.UnitTests.Domain.Entities.PaymentMethod;

[Collection(nameof(CreditCardPaymentTestFixture))]
public class CreditCardPaymentTest
{
    private readonly CreditCardPaymentTestFixture _fixture;

    public CreditCardPaymentTest(CreditCardPaymentTestFixture fixture)
        => _fixture = fixture;


    [Fact(DisplayName = nameof(InstantiateCreditCardPayment))]
    [Trait("Domain", "PaymentMethod")]
    public void InstantiateCreditCardPayment()
    {
        var creditCardPayment = _fixture.GetValidCreditCardPayment();

        creditCardPayment.Id.Should().NotBeEmpty();
        creditCardPayment.CardNumber.Should().NotBeNullOrEmpty();
        creditCardPayment.CardHolderName.Should().NotBeNullOrEmpty();
        creditCardPayment.ExpiryDate.Should().BeAfter(DateTime.Now);
        creditCardPayment.Cvv.Should().NotBeNullOrEmpty();
        creditCardPayment.Amount.Should().BeGreaterThan(0);
    }

    [Fact(DisplayName = nameof(InstantiateCreditCardPaymentWithInvalidNumber))]
    [Trait("Domain", "PaymentMethod")]
    public void InstantiateCreditCardPaymentWithInvalidNumber()
    {
        var creditCardPayment = _fixture.GetValidCreditCardPayment();

        Action act = () => new DomainEntity.CreditCardPayment(
            "",
            creditCardPayment.CardHolderName,
            creditCardPayment.ExpiryDate,
            creditCardPayment.Cvv,
            creditCardPayment.Amount);

        act.Should().Throw<ArgumentException>()
            .WithMessage("CardNumber cannot be empty");

    }

    [Fact(DisplayName = nameof(InstantiateCreditCardPaymentWithInvalidCardHolderName))]
    [Trait("Domain", "PaymentMethod")]
    public void InstantiateCreditCardPaymentWithInvalidCardHolderName()
    {
        var creditCardPayment = _fixture.GetValidCreditCardPayment();

        Action act = () => new DomainEntity.CreditCardPayment(
                       creditCardPayment.CardNumber,
                                  "",
                                  creditCardPayment.ExpiryDate,
                                  creditCardPayment.Cvv,
                                  creditCardPayment.Amount);

        act.Should().Throw<ArgumentException>()
            .WithMessage("CardHolderName cannot be empty");
    }

    [Fact(DisplayName = nameof(InstantiateCreditCardPaymentWithInvalidExpiryDate))]
    [Trait("Domain", "PaymentMethod")]
    public void InstantiateCreditCardPaymentWithInvalidExpiryDate()
    {
        var creditCardPayment = _fixture.GetValidCreditCardPayment();

        Action act = () => new DomainEntity.CreditCardPayment(
                       creditCardPayment.CardNumber,
                                  creditCardPayment.CardHolderName,
                                  DateTime.Now.AddDays(-1),
                                  creditCardPayment.Cvv,
                                  creditCardPayment.Amount);

        act.Should().Throw<ArgumentException>()
            .WithMessage("ExpiryDate cannot be in the past");


    }

    [Fact(DisplayName = nameof(InstantiateCreditCardPaymentWithInvalidCvv))]
    [Trait("Domain", "PaymentMethod")]
    public void InstantiateCreditCardPaymentWithInvalidCvv()
    {
        var creditCardPayment = _fixture.GetValidCreditCardPayment();

        Action act = () => new DomainEntity.CreditCardPayment(
                                  creditCardPayment.CardNumber,
                                  creditCardPayment.CardHolderName,
                                  creditCardPayment.ExpiryDate,
                                  "",
                                  creditCardPayment.Amount);

        act.Should().Throw<ArgumentException>()
            .WithMessage("Cvv cannot be empty");
    }

    [Fact(DisplayName = nameof(InstantiateCreditCardPaymentWithInvalidAmount))]
    [Trait("Domain", "PaymentMethod")]
    public void InstantiateCreditCardPaymentWithInvalidAmount()
    {
        var creditCardPayment = _fixture.GetValidCreditCardPayment();

        Action act = () => new DomainEntity.CreditCardPayment(
            creditCardPayment.CardNumber,
            creditCardPayment.CardHolderName,
            creditCardPayment.ExpiryDate,
            creditCardPayment.Cvv,
            0);

        act.Should().Throw<ArgumentException>()
            .WithMessage("Amount cannot be less than or equal to 0");
    }

    [Fact(DisplayName = nameof(InstantiateCreditCardPaymentWithInvalidCardNumberLength))]
    [Trait("Domain", "PaymentMethod")]
    public void InstantiateCreditCardPaymentWithInvalidCardNumberLength()
    {
        var creditCardPayment = _fixture.GetValidCreditCardPayment();

        Action act = () => new DomainEntity.CreditCardPayment(
                       "123456789012345",
                                  creditCardPayment.CardHolderName,
                                  creditCardPayment.ExpiryDate,
                                  creditCardPayment.Cvv,
                                  creditCardPayment.Amount);

        act.Should().Throw<ArgumentException>()
            .WithMessage("CardNumber must have 16 digits");
    }
    [Fact(DisplayName = nameof(InstantiateCreditCardPaymentWithInvalidCardNumberLengthLess))]
    [Trait("Domain", "PaymentMethod")]
    public void InstantiateCreditCardPaymentWithInvalidCardNumberLengthLess()
    {
        var creditCardPayment = _fixture.GetValidCreditCardPayment();

        Action act = () => new DomainEntity.CreditCardPayment(
            "123456789",
            creditCardPayment.CardHolderName,
            creditCardPayment.ExpiryDate,
            creditCardPayment.Cvv,
            creditCardPayment.Amount);

        act.Should().Throw<ArgumentException>()
            .WithMessage("CardNumber must have 16 digits");
    }

    [Fact(DisplayName = nameof(InstantiateCreditCardPaymentWithInvalidCvvLength))]
    [Trait("Domain", "PaymentMethod")]
    public void InstantiateCreditCardPaymentWithInvalidCvvLength()
    {
        var creditCardPayment = _fixture.GetValidCreditCardPayment();

        Action act = () => new DomainEntity.CreditCardPayment(
            creditCardPayment.CardNumber,
            creditCardPayment.CardHolderName,
            creditCardPayment.ExpiryDate,
            "1234",
            creditCardPayment.Amount);

        act.Should().Throw<ArgumentException>()
            .WithMessage("Cvv must have 3 digits");
    }


    [Fact(DisplayName = nameof(InstantiateCreditCardPaymentWithInvalidCvvLengthLess))]
    [Trait("Domain", "PaymentMethod")]
    public void InstantiateCreditCardPaymentWithInvalidCvvLengthLess()
    {
        var creditCardPayment = _fixture.GetValidCreditCardPayment();

        Action act = () => new DomainEntity.CreditCardPayment(
                       creditCardPayment.CardNumber,
                                  creditCardPayment.CardHolderName,
                                  creditCardPayment.ExpiryDate,
                                  "12",
                                  creditCardPayment.Amount);

        act.Should().Throw<ArgumentException>()
            .WithMessage("Cvv must have 3 digits");
    }


}



using PaymentGateway.UnitTests.Domain.Common;

namespace PaymentGateway.UnitTests.Domain.Entities.PaymentMethod;

[CollectionDefinition(nameof(CreditCardPaymentTestFixture))]
public class CreditCardPaymentTestFixtureCollection : ICollectionFixture<CreditCardPaymentTestFixture>
{
}

public class CreditCardPaymentTestFixture : BaseFixture
{
}

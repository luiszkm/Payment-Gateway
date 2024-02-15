using Stripe;

namespace PaymentGateway.Infra.Stripe.Configurations;
internal class StripeConnection
{
    public StripeConnection(string apiKey)
    {
        StripeConfiguration.ApiKey = apiKey;
    }
    public string ApiKey { get; set; }
}

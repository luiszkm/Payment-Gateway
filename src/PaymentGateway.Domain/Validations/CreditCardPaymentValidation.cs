

using System.Text.RegularExpressions;
using PaymentGateway.Domain.Entities;

namespace PaymentGateway.Domain.Validations;
public class CreditCardPaymentValidation : BaseValidation
{
    public static void ValidateCreditCardPayment(CreditCardPayment creditCardPayment)
    {
        ValidateId(creditCardPayment.Id);
        ValidateString(creditCardPayment.CardNumber, nameof(creditCardPayment.CardNumber));
        ValidateString(creditCardPayment.CardHolderName, nameof(creditCardPayment.CardHolderName));
        // ValidateDate(creditCardPayment.ExpiryDate, nameof(creditCardPayment.ExpiryDate));
        ValidateString(creditCardPayment.Cvv, nameof(creditCardPayment.Cvv));
        ValidateDecimal(creditCardPayment.Amount, nameof(creditCardPayment.Amount));
        ValidateCreditCardNumber(creditCardPayment.CardNumber, nameof(creditCardPayment.CardNumber));
        ValidateCvv(creditCardPayment.Cvv, nameof(creditCardPayment.Cvv));
    }

    public static void ValidateCreditCardNumber(string value, string fieldName)
    {
        var cardNumber = value.Replace("-", "");
        if (cardNumber.Length != 16)
            throw new ArgumentException($"{fieldName} must have 16 digits");

        if (string.IsNullOrEmpty(value))
            throw new ArgumentException($"{fieldName} cannot be empty");


    }

    public static void ValidateCvv(string value, string fieldName)
    {
        var regex = new Regex(@"^\d{3}$");
        if (!regex.IsMatch(value))
            throw new ArgumentException($"{fieldName} must have 3 digits");

        if (string.IsNullOrEmpty(value))
            throw new ArgumentException($"{fieldName} cannot be empty");

        if (value.Length != 3)
            throw new ArgumentException($"{fieldName} must have 3 digits");
    }

}

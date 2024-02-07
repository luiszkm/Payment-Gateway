

namespace PaymentGateway.Domain.Validations;
public abstract class BaseValidation
{

    public static void ValidateId(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Id cannot be empty");
    }

    public static void ValidateString(string value, string fieldName)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException($"{fieldName} cannot be empty");
    }

    public static void ValidateDate(DateTime value, string fieldName)
    {
        if (value < DateTime.Now)
            throw new ArgumentException($"{fieldName} cannot be in the past");
    }

    public static void ValidateDecimal(decimal value, string fieldName)
    {
        if (value <= 0)
            throw new ArgumentException($"{fieldName} cannot be less than or equal to 0");
    }






}

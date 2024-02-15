using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Application.UseCases;

namespace PaymentGateway.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly IProcessPayment _processPayment;

    public PaymentController(IProcessPayment processPayment)
    {
        _processPayment = processPayment;
    }

    [HttpPost]

    public IActionResult ProcessPayment([FromBody] ProcessPaymentInput input)
    {
        var output = _processPayment.Execute(input);

        return Accepted(output);
    }
}

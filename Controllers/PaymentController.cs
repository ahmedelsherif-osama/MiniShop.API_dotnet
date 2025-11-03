using Microsoft.AspNetCore.Mvc;
using MiniShopAPI.Models;
using MiniShopAPI.Models.DTOs;
using MiniShopAPI.Models.Payments;
using MiniShopAPI.Services;

namespace MiniShopAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly PaymentService _paymentService;

    public PaymentController(PaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    // POST: /api/payments/{provider}
    [HttpPost("{provider}")]
    public async Task<ActionResult> ProcessPayment(string provider, [FromBody] PaymentRequestDto request)
    {
        try
        {
            // Step 1️⃣: Map DTO → payment model (simplified)
            Payment payment = provider.ToLower() switch
            {
                "stripe" => new CardPayment
                {
                    Amount = request.Amount,
                    Currency = request.Currency,
                    CardHolder = request.CustomerName,
                    Last4Digits = request.Last4Digits
                },
                "paypal" => new WalletPayment
                {
                    Amount = request.Amount,
                    Currency = request.Currency,
                    WalletProvider = "PayPal",
                    PayerEmail = request.CustomerEmail
                },
                "cash" => new CashPayment
                {
                    Amount = request.Amount,
                    Currency = request.Currency
                },
                _ => throw new ArgumentException($"Unsupported provider: {provider}")
            };

            // Step 2️⃣: Process payment using proper processor
            var result = await _paymentService.ProcessPaymentAsync(payment, provider);

            // Step 3️⃣: Return response
            if (result.Success)
                return Ok(new
                {
                    Message = "Payment successful",
                    PaymentId = payment.Id,
                    Provider = provider,
                    RedirectUrl = result.RedirectUrl
                });

            return BadRequest(new { Message = "Payment failed", Provider = provider });
        }
        catch (Exception ex)
        {
            // Step 4️⃣: Handle and log errors
            return StatusCode(500, new { Message = "Payment processing error", Error = ex.Message });
        }
    }
}

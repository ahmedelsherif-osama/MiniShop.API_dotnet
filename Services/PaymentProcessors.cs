using MiniShopAPI.DTOs;
using MiniShopAPI.Interfaces;
using MiniShopAPI.Models.Payments;
using Stripe;

namespace MiniShopAPI.Services;

public interface IPaymentProcessor
{
    Task<PaymentResult> ProcessAsync(Payment payment);
}

public class StripeProcessor : IPaymentProcessor
{
    private readonly IConfiguration _config;

    public StripeProcessor(IConfiguration config)
    {
        _config = config;
    }

    public async Task<PaymentResult> ProcessAsync(Payment payment)
    {
        // 1️⃣ Configure Stripe API key
        var stripeApiKey = _config["Stripe:ApiKey"];
        StripeConfiguration.ApiKey = stripeApiKey;

        // 2️⃣ Create payment intent
        var options = new PaymentIntentCreateOptions
        {
            Amount = (long)(payment.Amount * 100),
            Currency = payment.Currency.ToLower(),
            PaymentMethodTypes = new List<string> { "card" }
        };

        var service = new PaymentIntentService();
        var intent = await service.CreateAsync(options);

        // 3️⃣ Return result
        return new PaymentResult
        {
            Success = true,
            ExternalId = intent.Id,
            RedirectUrl = intent.ClientSecret
        };
    }
}


public class PayPalProcessor : IPaymentProcessor
{
    private readonly HttpClient _httpClient;

    public PayPalProcessor(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<PaymentResult> ProcessAsync(Payment payment)
    {
        var request = new
        {
            intent = "CAPTURE",
            purchase_units = new[] {
                new { amount = new { currency_code = payment.Currency, value = payment.Amount } }
            }
        };

        var response = await _httpClient.PostAsJsonAsync("https://api.paypal.com/v2/checkout/orders", request);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<PayPalResponse>();
        return new PaymentResult
        {
            Success = true,
            ExternalId = content!.Id,
            RedirectUrl = content.Links.First(l => l.Rel == "approve").Href
        };
    }
}

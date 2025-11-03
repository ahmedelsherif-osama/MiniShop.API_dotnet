using MiniShopAPI.DTOs;
using MiniShopAPI.Interfaces;
using MiniShopAPI.Models.Payments;

namespace MiniShopAPI.Services;

public class PaymentService
{
    private readonly Dictionary<string, IPaymentProcessor> _processors;
    private readonly AppDbContext _context;

    public PaymentService(StripeProcessor stripe, PayPalProcessor paypal, AppDbContext context)
    {
        _processors = new()
        {
            { "stripe", stripe },
            { "paypal", paypal }
        };
        _context = context;
    }

    public async Task<PaymentResult> ProcessPaymentAsync(Payment payment, string provider)
    {
        var processor = _processors[provider.ToLower()];
        var result = await processor.ProcessAsync(payment);

        payment.Status = result.Success ? "Success" : "Failed";
        await _context.Payments.AddAsync(payment);
        await _context.SaveChangesAsync();

        return result;
    }
}

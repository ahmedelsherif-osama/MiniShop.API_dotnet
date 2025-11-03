namespace MiniShopAPI.DTOs;

public class PaymentResult
{
    public bool Success { get; set; }
    public string? ExternalId { get; set; }
    public string? RedirectUrl { get; set; }
}

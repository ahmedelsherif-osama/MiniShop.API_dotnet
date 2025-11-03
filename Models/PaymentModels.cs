namespace MiniShopAPI.Models.Payments;

public abstract class Payment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid OrderId { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "USD";
    public string Status { get; set; } = "Pending";  // Pending, Success, Failed
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public class CashPayment : Payment
{

    public string Provider { get; set; } = "Cash"; // Could be Stripe, Adyen, etc.
}
public class CardPayment : Payment
{
    public string CardHolder { get; set; }
    public string Last4Digits { get; set; }
    public string Provider { get; set; } = "Stripe"; // Could be Stripe, Adyen, etc.
    public string ExternalPaymentId { get; set; }    // Stripe charge ID
}

public class WalletPayment : Payment
{
    public string WalletProvider { get; set; } = "PayPal";
    public string ExternalPaymentId { get; set; }
    public string PayerEmail { get; set; }
}

public class CryptoPayment : Payment
{
    public string WalletAddress { get; set; }
    public string TxHash { get; set; }
}

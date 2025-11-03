namespace MiniShopAPI.Models.DTOs
{
    public class PaymentRequestDto
    {
        /// <summary>
        /// The total amount to be charged (in smallest currency unit if required by provider)
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Currency code (e.g., USD, EUR, SAR)
        /// </summary>
        public string Currency { get; set; } = string.Empty;

        /// <summary>
        /// Name of the customer making the payment
        /// </summary>
        public string CustomerName { get; set; } = string.Empty;

        /// <summary>
        /// Customer's email (used for PayPal or wallet payments)
        /// </summary>
        public string? CustomerEmail { get; set; }

        /// <summary>
        /// Last 4 digits of card (used only for card payments)
        /// </summary>
        public string? Last4Digits { get; set; }

        /// <summary>
        /// Optional order or reference ID (helps track what this payment belongs to)
        /// </summary>
        public string? ReferenceId { get; set; }

        /// <summary>
        /// Optional metadata or notes about this payment
        /// </summary>
        public string? Notes { get; set; }
    }
}

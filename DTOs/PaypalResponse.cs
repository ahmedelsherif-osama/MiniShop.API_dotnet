namespace MiniShopAPI.DTOs
{
    public class PayPalResponse
    {
        public string Id { get; set; } = string.Empty;
        public List<PayPalLink> Links { get; set; } = new();
    }

    public class PayPalLink
    {
        public string Href { get; set; } = string.Empty;
        public string Rel { get; set; } = string.Empty;
        public string Method { get; set; } = string.Empty;
    }
}

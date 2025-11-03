using MiniShopAPI.DTOs;
using MiniShopAPI.Models.Payments;

namespace MiniShopAPI.Interfaces;

public interface IPaymentProcessor
{
    Task<PaymentResult> ProcessAsync(Payment payment);
}

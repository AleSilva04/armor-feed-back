using ArmorFeedApi.Payments.Domain.Model;
using ArmorFeedApi.Payments.Domain.Services.Communication;

namespace ArmorFeedApi.Payments.Domain.Services;

public interface IPaymentService
{
    Task<IEnumerable<Payment>> ListAsync();
    Task<IEnumerable<Payment>> ListByShipmentIdAsync(int shipmentId);
    Task<PaymentResponse> SaveAsync(Payment payment);
    Task<PaymentResponse> UpdateAsync(int paymentId, Payment payment);
    Task<PaymentResponse> DeleteAsync(int paymentId);
}
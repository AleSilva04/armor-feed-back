using ArmorFeedApi.Payments.Domain.Model;

namespace ArmorFeedApi.Payments.Domain.Repositories;

public interface IPaymentRepository
{
    Task<IEnumerable<Payment>> ListAsync();
    Task AddAsync(Payment payment);
    Task<Payment> FindByIdAsync(int paymentId);
    Task<Payment> FindByShipmentIdAsync(int shipmentId);
    void Update(Payment payment);
    void Remove(Payment payment);

}
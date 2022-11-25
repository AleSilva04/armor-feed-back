using ArmorFeedApi.Payments.Domain.Model;
using ArmorFeedApi.Payments.Domain.Repositories;
using ArmorFeedApi.Shared.Persistence.Contexts;
using ArmorFeedApi.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ArmorFeedApi.Payments.Persistence.Repositories;

public class PaymentRepository: BaseRepository, IPaymentRepository
{
    public PaymentRepository(AppDbContext context) : base(context){}

    public async Task<IEnumerable<Payment>> ListAsync()
    {
        return await _context.Payments.ToListAsync();
    }

    public async Task AddAsync(Payment payment)
    {
        await _context.Payments.AddAsync(payment);
    }

    public async Task<Payment> FindByIdAsync(int paymentId)
    {
        return await _context.Payments.FirstOrDefaultAsync(p => p.Id == paymentId);
    }

    public async Task<Payment> FindByShipmentIdAsync(int shipmentId)
    {
        return await _context.Payments.FirstOrDefaultAsync(p => p.ShipmentId == shipmentId);
    }

    public void Update(Payment payment)
    {
        _context.Payments.Update(payment);
    }

    public void Remove(Payment payment)
    {
        _context.Payments.Remove(payment);
    }
}
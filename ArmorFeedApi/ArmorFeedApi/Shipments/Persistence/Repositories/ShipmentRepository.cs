using System.Runtime.CompilerServices;
using ArmorFeedApi.Shared.Persistence.Contexts;
using ArmorFeedApi.Shared.Persistence.Repositories;
using ArmorFeedApi.Shipments.Domain.Models;
using ArmorFeedApi.Shipments.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ArmorFeedApi.Shipments.Persistence.Repositories;

public class ShipmentRepository: BaseRepository, IShipmentRepository
{
    public ShipmentRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Shipment>> ListAsync()
    {
        return await _context.Shipments.ToListAsync();
    }

    public async Task AddAsync(Shipment shipment)
    {
        await _context.Shipments.AddAsync(shipment);
    }

    public async Task<Shipment> FindByIdAsync(int id)
    {
        return await _context.Shipments.FindAsync(id);
    }

    public void Update(Shipment shipment)
    {
        _context.Shipments.Update(shipment);
    }

    public void Remove(Shipment shipment)
    {
        _context.Shipments.Remove(shipment);
    }

    public async Task<IEnumerable<Shipment>> FindByEnterpriseId(int enterpriseId)
    {
        return await _context.Shipments
            .Where(s => s.EnterpriseId == enterpriseId)
            .Include(s => s.Enterprise)
            .ToListAsync();
    }

    public async Task<IEnumerable<Shipment>> FindByCustomerId(int customerId)
    {
        return await _context.Shipments
            .Where(s => s.CustomerId == customerId)
            .Include(s => s.Customer)
            .ToListAsync();
    }
}
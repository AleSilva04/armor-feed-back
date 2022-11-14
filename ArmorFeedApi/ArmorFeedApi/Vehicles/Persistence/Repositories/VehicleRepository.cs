

using ArmorFeedApi.Shared.Persistence.Contexts;
using ArmorFeedApi.Shared.Persistence.Repositories;
using ArmorFeedApi.Vehicles.Domain.Models;
using ArmorFeedApi.Vehicles.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ArmorFeedApi.Vehicles.Persistence.Repositories;

public class VehicleRepository: BaseRepository, IVehicleRepository
{
    public VehicleRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<Vehicle>> ListAsync()
    {
        return await _context.Vehicles.ToListAsync();
    }
    
    public async Task<IEnumerable<Vehicle>> FindByEnterpriseId(int id)
    {
        return await _context.Vehicles
            .Where(p => p.EnterpriseId == id)
            .Include(p => p.Enterprise)
            .ToListAsync();
    }
    

    public async Task AddAsync(Vehicle vehicle)
    {
        await _context.Vehicles.AddAsync(vehicle);
    }

    public async Task<Vehicle> FindByIdAsync(int id)
    {
        return await _context.Vehicles.FindAsync(id);
    }

    public void Update(Vehicle vehicle)
    {
        _context.Vehicles.Update(vehicle);
    }

    public void Remove(Vehicle vehicle)
    {
        _context.Vehicles.Remove(vehicle);
    }
   
}
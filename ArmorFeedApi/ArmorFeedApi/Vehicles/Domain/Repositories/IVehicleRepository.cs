

using ArmorFeedApi.Vehicles.Domain.Models;

namespace ArmorFeedApi.Vehicles.Domain.Repositories;

public interface IVehicleRepository
{
    Task<IEnumerable<Vehicle>> ListAsync();
    Task<IEnumerable<Vehicle>> FindByEnterpriseId(int id);
    Task AddAsync(Vehicle vehicle);
    Task<Vehicle> FindByIdAsync(int id);
    void Update(Vehicle vehicle);
    void Remove(Vehicle vehicle);
}
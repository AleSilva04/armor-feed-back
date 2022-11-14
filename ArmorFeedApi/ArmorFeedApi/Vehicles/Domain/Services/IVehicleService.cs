
using ArmorFeedApi.Vehicles.Domain.Models;
using ArmorFeedApi.Vehicles.Domain.Services.Communication;

namespace ArmorFeedApi.Vehicles.Domain.Services;

public interface IVehicleService
{
    Task<IEnumerable<Vehicle>> ListAsync();

    Task<IEnumerable<Vehicle>> ListByEnterpriseAsync(int enterpriseId);

    Task<Vehicle> FindByIdAsync(int id);
    Task<VehicleResponse> SaveAsync(Vehicle vehicle);
    Task<VehicleResponse> UpdateAsync(int id, Vehicle vehicle);
    Task<VehicleResponse> DeleteAsync(int id);
}
using ArmorFeedApi.Shipments.Domain.Models;

namespace ArmorFeedApi.Shipments.Domain.Repositories;

public interface IShipmentRepository
{
    Task<IEnumerable<Shipment>> ListAsync();
    Task AddAsync(Shipment shipment);
    Task<Shipment> FindByIdAsync(int id);
    void Update(Shipment shipment);
    void Remove(Shipment shipment);
    Task<IEnumerable<Shipment>> FindByEnterpriseId(int enterpriseId);
    Task<IEnumerable<Shipment>> FindByCustomerId(int customerId);
}
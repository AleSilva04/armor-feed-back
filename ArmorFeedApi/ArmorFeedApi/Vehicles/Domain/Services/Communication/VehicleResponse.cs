

using ArmorFeedApi.Shared.Domain.Services.Communication;
using ArmorFeedApi.Vehicles.Domain.Models;

namespace ArmorFeedApi.Vehicles.Domain.Services.Communication;

public class VehicleResponse : BaseResponse<Vehicle>
{
    public VehicleResponse(Vehicle resource) : base(resource)
    {
    }

    public VehicleResponse(string message) : base(message)
    {
    }
}
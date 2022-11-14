using ArmorFeedApi.Enterprises.Domain.Models;
using ArmorFeedApi.Shared.Domain.Services.Communication;

namespace ArmorFeedApi.Enterprises.Domain.Services.Communication;

public class EnterpriseResponse: BaseResponse<Enterprise>
{
    public EnterpriseResponse(Enterprise resource) : base(resource)
    {
    }

    public EnterpriseResponse(string message) : base(message)
    {
    }
}
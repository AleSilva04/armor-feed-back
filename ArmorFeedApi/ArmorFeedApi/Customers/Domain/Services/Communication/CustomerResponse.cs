using ArmorFeedApi.Customers.Domain.Models;
using ArmorFeedApi.Shared.Domain.Services.Communication;

namespace ArmorFeedApi.Customers.Domain.Services.Communication;

public class CustomerResponse:BaseResponse<Customer>
{
    public CustomerResponse(Customer resource) : base(resource)
    {
    }

    public CustomerResponse(string message) : base(message)
    {
    }
}
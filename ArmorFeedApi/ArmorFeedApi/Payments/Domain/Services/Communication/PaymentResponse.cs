using ArmorFeedApi.Payments.Domain.Model;
using ArmorFeedApi.Shared.Domain.Services.Communication;

namespace ArmorFeedApi.Payments.Domain.Services.Communication;

public class PaymentResponse : BaseResponse<Payment>
{
    public PaymentResponse(Payment resource): base(resource){}
    public PaymentResponse(string message): base(message){}
}
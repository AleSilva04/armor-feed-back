using ArmorFeedApi.Payments.Domain.Model;
using ArmorFeedApi.Payments.Domain.Repositories;
using ArmorFeedApi.Payments.Domain.Services;
using ArmorFeedApi.Payments.Domain.Services.Communication;
using IUnitOfWork = ArmorFeedApi.Shared.Domain.Repositories.IUnitOfWork;

namespace ArmorFeedApi.Payments.Services;

public class PaymentService: IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public PaymentService(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork)
    {
        _paymentRepository = paymentRepository;
        _unitOfWork = unitOfWork;
        
    }

    public async Task<IEnumerable<Payment>> ListAsync()
    {
        return await _paymentRepository.ListAsync();
    }

    public async Task<Payment> ListByShipmentIdAsync(int shipmentId)
    {
        return await _paymentRepository.FindByShipmentIdAsync(shipmentId);
    }

    public async Task<PaymentResponse> SaveAsync(Payment payment)
    {
        try
        {
            await _paymentRepository.AddAsync(payment);
            await _unitOfWork.CompleteAsync();
            return new PaymentResponse(payment);
        }
        catch (Exception e)
        {
            return new PaymentResponse($"An error occurred while saving the payments: {e.Message}");
        }
    }

    public async Task<PaymentResponse> UpdateAsync(int paymentId, Payment payment)
    {
        var existingPayment = await _paymentRepository.FindByIdAsync(paymentId);
        if (existingPayment == null)
            return new PaymentResponse("Payment not found.");

        existingPayment.Amount = payment.Amount;
        existingPayment.Currency = payment.Currency;
        existingPayment.PaymentDate = payment.PaymentDate;
        try
        {
            _paymentRepository.Update(existingPayment);
            await _unitOfWork.CompleteAsync();
            return new PaymentResponse(existingPayment);
        }
        catch (Exception e)
        {
            return new PaymentResponse($"An error occurred while updating the tutorial: {e.Message}");
        }
    }

    public async Task<PaymentResponse> DeleteAsync(int paymentId)
    {
        var existingPayment = await _paymentRepository.FindByIdAsync(paymentId);
        if (existingPayment == null)
            return new PaymentResponse("Payment not found.");
        try
        {
            _paymentRepository.Remove(existingPayment);
            await _unitOfWork.CompleteAsync();
            return new PaymentResponse(existingPayment);
        }
        catch (Exception e)
        {
            return new PaymentResponse($"An error occurred while deleting the tutorial: {e.Message}");
        }
    }

}
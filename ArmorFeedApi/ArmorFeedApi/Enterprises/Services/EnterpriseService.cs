using ArmorFeedApi.Enterprises.Domain.Models;
using ArmorFeedApi.Enterprises.Domain.Repositories;
using ArmorFeedApi.Enterprises.Domain.Services;
using ArmorFeedApi.Enterprises.Domain.Services.Communication;
using ArmorFeedApi.Shared.Domain.Repositories;

namespace ArmorFeedApi.Enterprises.Services;

public class EnterpriseService:IEnterpriseService
{
    private readonly IEnterpriseRepository _enterpriseRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public EnterpriseService(IEnterpriseRepository enterpriseRepository, IUnitOfWork unitOfWork)
    {
        _enterpriseRepository = enterpriseRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Enterprise>> ListAsync()
    {
        return await _enterpriseRepository.ListAsync();
    }

    public async Task<EnterpriseResponse> SaveAsync(Enterprise enterprise)
    {
        try
        {
            await _enterpriseRepository.AddAsync(enterprise);
            await _unitOfWork.CompleteAsync();

            return new EnterpriseResponse(enterprise);
        }
        catch (Exception e)
        {
            return new EnterpriseResponse($"An error occurred while saving the enterprise: {e.Message}");
        }
    }

    public async Task<EnterpriseResponse> UpdateAsync(int id, Enterprise enterprise)
    {
        var existingEnterprise = await _enterpriseRepository.FindByIdAsync(id);

        if (existingEnterprise == null)
            return new EnterpriseResponse("Enterprise not found.");

        existingEnterprise.Name = enterprise.Name;

        try
        {
            _enterpriseRepository.Update(existingEnterprise);
            await _unitOfWork.CompleteAsync();

            return new EnterpriseResponse(existingEnterprise);
        }
        catch (Exception e)
        {
            return new EnterpriseResponse($"An error occurred while updating the enterprise: {e.Message}");
        }
    }

    public async Task<EnterpriseResponse> DeleteAsync(int id)
    {
        var existingEnterprise = await _enterpriseRepository.FindByIdAsync(id);

        if (existingEnterprise == null)
            return new EnterpriseResponse("Enterprise not found.");

        try
        {
            _enterpriseRepository.Remove(existingEnterprise);
            await _unitOfWork.CompleteAsync();

            return new EnterpriseResponse(existingEnterprise);
        }
        catch (Exception e)
        {
            return new EnterpriseResponse($"An error occurred while deleting the enterprise: {e.Message}");
        }
    }
}
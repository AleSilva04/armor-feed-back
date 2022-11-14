

using ArmorFeedApi.Enterprises.Domain.Repositories;
using ArmorFeedApi.Shared.Domain.Repositories;
using ArmorFeedApi.Vehicles.Domain.Models;
using ArmorFeedApi.Vehicles.Domain.Repositories;
using ArmorFeedApi.Vehicles.Domain.Services;
using ArmorFeedApi.Vehicles.Domain.Services.Communication;

namespace ArmorFeedApi.Vehicles.Services;

 public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
       
        private readonly IEnterpriseRepository _enterpriseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public VehicleService(IVehicleRepository vehicleRepository, IEnterpriseRepository enterpriseRepository, IUnitOfWork unitOfWork)
        {
            _vehicleRepository = vehicleRepository;
            
            _enterpriseRepository = enterpriseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Vehicle>> ListAsync()
        {
            return await _vehicleRepository.ListAsync();
        }
        
        public async Task<IEnumerable<Vehicle>> ListByEnterpriseAsync(int enterpriseId)
        {
            return await _vehicleRepository.FindByEnterpriseId(enterpriseId);
        }

      

        public async Task<Vehicle> FindByIdAsync(int id)
        {
            var vehicle = await _vehicleRepository.FindByIdAsync(id);
            return vehicle;
        }

        public async Task<VehicleResponse> SaveAsync(Vehicle vehicle)
        {
            
            var existingEnterprise = await _enterpriseRepository.FindByIdAsync(vehicle.EnterpriseId);
            if (existingEnterprise == null)
            {
                return new VehicleResponse("Enterprise not found.");
            }
            
            try
            {
                await _vehicleRepository.AddAsync(vehicle);
                await _unitOfWork.CompleteAsync();
                return new VehicleResponse(vehicle);
            }
            catch (Exception e)
            {
                return new VehicleResponse($"An error occurred while saving the vehicle: {e.Message}");
            }
        }

        public async Task<VehicleResponse> UpdateAsync(int id, Vehicle vehicle)
        {
            var existingVehicle = await _vehicleRepository.FindByIdAsync(id);
            if (existingVehicle == null)
            {
                return new VehicleResponse("Vehicle not found");
            }

            existingVehicle.Brand = vehicle.Brand;
            existingVehicle.LicensePlate = vehicle.LicensePlate;
            existingVehicle.Year= vehicle.Year;
            existingVehicle.Model = vehicle.Model;
            existingVehicle.MaintenanceDate= vehicle.MaintenanceDate;
            existingVehicle.VehicleType = vehicle.VehicleType;

            try
            {
                _vehicleRepository.Update(existingVehicle);
                await _unitOfWork.CompleteAsync();
                return new VehicleResponse(existingVehicle);
            }
            catch (Exception e)
            {
                return new VehicleResponse($"An error occurred while updating the vehicle: {e.Message}");
            }
        }

        public async Task<VehicleResponse> DeleteAsync(int id)
        {
            var existingVehicle = await _vehicleRepository.FindByIdAsync(id);
            if (existingVehicle == null)
            {
                return new VehicleResponse("Vehicle not found");
            }

            try
            {
                _vehicleRepository.Remove(existingVehicle);
                await _unitOfWork.CompleteAsync();
                return new VehicleResponse(existingVehicle);
            }
            catch (Exception e)
            {
                return new VehicleResponse($"An error occurred while deleting the vehicle: {e.Message}");
            }
        }
    }
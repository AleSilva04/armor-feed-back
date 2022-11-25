using ArmorFeedApi.Customers.Domain.Models;
using ArmorFeedApi.Customers.Domain.Repositories;
using ArmorFeedApi.Customers.Domain.Services;
using ArmorFeedApi.Customers.Domain.Services.Communication;
using ArmorFeedApi.Security.Authorization.Handlers.Interfaces;
using ArmorFeedApi.Security.Domain.Services.Communication;
using ArmorFeedApi.Security.Exceptions;
using ArmorFeedApi.Shared.Domain.Repositories;
using AutoMapper;
using BCryptNet = BCrypt.Net.BCrypt;

namespace ArmorFeedApi.Customers.Services;

public class CustomerService:  ICustomerService
{
     private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IJwtHandler<Customer> _jwtHandler;

    public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork, IMapper mapper, IJwtHandler<Customer> jwtHandler)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _jwtHandler = jwtHandler;
    }

    public async Task<AuthenticateCustomerResponse> Authenticate(AuthenticateRequest request)
    {
        var user = await _customerRepository.FindByEmailAsync(request.Email);
        Console.WriteLine($"Request: {request.Email}, {request.Password}");
        Console.WriteLine($"User: {user.Id}, {user.Name}, {user.PhoneNumber}, {user.Description}, {user.Ruc}, {user.Email}, {user.PasswordHash}");
        
        //Perform validation
        if (user==null || !BCryptNet.Verify(request.Password,user.PasswordHash))
        {
            Console.WriteLine("Authentication Error");
            throw new AppException("Email or password is incorrect.");
        }
        Console.WriteLine("Authentication succesful. About to generate");
        var response = _mapper.Map<AuthenticateCustomerResponse>(user);
        Console.WriteLine($"Response: {response.Id}, {response.Name}, {response.PhoneNumber}, {response.Description}, {response.Ruc}, {response.Email}");
        response.Token = _jwtHandler.GenerateToken(user);
        Console.WriteLine($"Generated token is {response.Token}");
        return response;
    }

    public async Task<IEnumerable<Customer>> ListAsync()
    {
        return await _customerRepository.ListAsync();
    }

    public async Task<Customer> GetByIdAsync(int id)
    {
        var user = await _customerRepository.FindByIdAsync(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }

    public async Task RegisterAsync(RegisterCustomerRequest request)
    {
        //Validate
        if (_customerRepository.ExitsByEmail(request.Email))
            throw new AppException($"Email '{request.Email}' is already token");
        
        //Map request to user entity
        var user = _mapper.Map<Customer>(request);
        
        //Hash password
        user.PasswordHash = BCryptNet.HashPassword(request.Password);
        
        //Save User
        try
        {
            await _customerRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while saving the user: {e.Message}");
        }
    }

    public async Task UpdateAsync(int id, UpdateCustomerRequest request)
    {
        var user = GetById(id);
        //Validate
        var userWithEmail = await _customerRepository.FindByEmailAsync(request.Email);
        if (userWithEmail != null && userWithEmail.Id != user.Id)
            throw new AppException($"Email '{request.Email}' is already taken");
        
        //Hash Password if it was entered
        if (!string.IsNullOrEmpty(request.Password))
            user.PasswordHash = BCryptNet.HashPassword(request.Password);
        
        //Map request to entity
        _mapper.Map(request, user);
        
        //Save User
        try
        {
            _customerRepository.Update(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while updating the user: {e.Message}");
        }
    }

    public async Task DeleteAsync(int id)
    {
        var user = GetById(id);
        try
        {
            _customerRepository.Remove(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while deleting the user: {e.Message}");
        }
    }
    private Customer GetById(int id)
    {
        var user = _customerRepository.FindById(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }
}
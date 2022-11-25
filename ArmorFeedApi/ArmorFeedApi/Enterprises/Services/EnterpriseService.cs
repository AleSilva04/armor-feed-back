using ArmorFeedApi.Enterprises.Domain.Models;
using ArmorFeedApi.Enterprises.Domain.Repositories;
using ArmorFeedApi.Enterprises.Domain.Services;
using ArmorFeedApi.Enterprises.Domain.Services.Communication;
using ArmorFeedApi.Security.Authorization.Handlers.Interfaces;
using ArmorFeedApi.Security.Domain.Services.Communication;
using ArmorFeedApi.Security.Exceptions;
using ArmorFeedApi.Shared.Domain.Repositories;
using AutoMapper;
using BCryptNet = BCrypt.Net.BCrypt;

namespace ArmorFeedApi.Enterprises.Services;

public class EnterpriseService: IEnterpriseService
{
    private readonly IEnterpriseRepository _enterpriseRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IJwtHandler<Enterprise> _jwtHandler;


    public EnterpriseService(IEnterpriseRepository enterpriseRepository, IUnitOfWork unitOfWork, IMapper mapper, IJwtHandler<Enterprise> jwtHandler)
    {
        _enterpriseRepository = enterpriseRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _jwtHandler = jwtHandler;
    }

    public async Task<AuthenticateEnterpriseResponse> Authenticate(AuthenticateRequest request)
    {
        var user = await _enterpriseRepository.FindByEmailAsync(request.Email);
        Console.WriteLine($"Request: {request.Email}, {request.Password}");
        Console.WriteLine($"User: {user.Id}, {user.Name}, {user.PhoneNumber}, {user.Description}, {user.Ruc}, {user.Email}, {user.PasswordHash}");
        
        //Perform validation
        if (user==null || !BCryptNet.Verify(request.Password,user.PasswordHash))
        {
            Console.WriteLine("Authentication Error");
            throw new AppException("Email or password is incorrect.");
        }
        Console.WriteLine("Authentication succesful. About to generate");
        var response = _mapper.Map<AuthenticateEnterpriseResponse>(user);
        Console.WriteLine($"Response: {response.Id}, {response.Name}, {response.PhoneNumber}, {response.Description}, {response.Ruc}, {response.Email}");
        response.Token = _jwtHandler.GenerateToken(user);
        Console.WriteLine($"Generated token is {response.Token}");
        return response;
    }

    public async Task<IEnumerable<Enterprise>> ListAsync()
    {
        return await _enterpriseRepository.ListAsync();
    }

    public async Task<Enterprise> GetByIdAsync(int id)
    {
        var user = await _enterpriseRepository.FindByIdAsync(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }

    public async Task DeleteAsync(int id)
    {
        var user = GetById(id);
        try
        {
            _enterpriseRepository.Remove(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while deleting the user: {e.Message}");
        }
    }

    public async Task RegisterAsync(RegisterEnterpriseRequest request)
    {
        //Validate
        if (_enterpriseRepository.ExitsByEmail(request.Email))
            throw new AppException($"Email '{request.Email}' is already token");
        
        //Map request to user entity
        var user = _mapper.Map<Enterprise>(request);
        
        //Hash password
        user.PasswordHash = BCryptNet.HashPassword(request.Password);
        
        //Save User
        try
        {
            await _enterpriseRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while saving the user: {e.Message}");
        }
    }

    public async Task UpdateAsync(int id, UpdateEnterpriseRequest request)
    {
        var user = GetById(id);
        //Validate
        var userWithEmail = await _enterpriseRepository.FindByEmailAsync(request.Email);
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
            _enterpriseRepository.Update(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while updating the user: {e.Message}");
        }
    }
    private Enterprise GetById(int id)
    {
        var user = _enterpriseRepository.FindById(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }
}
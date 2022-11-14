using ArmorFeedApi.Customers.Domain.Models;
using ArmorFeedApi.Security.Domain.Respositories;

namespace ArmorFeedApi.Customers.Domain.Repositories;

public interface ICustomerRepository: IUserRepository<Customer>
{

}
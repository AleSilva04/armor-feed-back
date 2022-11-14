namespace ArmorFeedApi.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}
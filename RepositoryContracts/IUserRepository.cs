using Entities;

namespace RepositoryContracts;

public interface IUserRepository
{
    Task<User> AddUser(User user);
    Task UpdateUser(User user);
    Task RemoveUser(User user);
    Task<User> GetUser(int id);
    IQueryable<User> GetUsers();
}
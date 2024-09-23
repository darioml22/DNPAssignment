using Entities;

namespace RepositoryContracts;

public interface IUserRepository
{
    Task<User> AddUser(User user);
    Task UpdateUser(User user);
    Task RemoveUser(int id);
    Task<User> GetUser(int id);
    IQueryable<User> GetUsers();
    List<User> GetAll();
}
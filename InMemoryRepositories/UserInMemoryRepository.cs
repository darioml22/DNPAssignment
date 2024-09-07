using Entities;
using RepositoryContracts;

namespace InMemoryRepositories;

public class UserInMemoryRepository : IUserRepository
{
    private List<User> users;

    public Task<User> AddUser(User user)
    {
        user.Id = users.Any()
            ? users.Max(u=> u.Id) + 1
            : 1;
        users.Add(user);
        return Task.FromResult(user);
    }

    public Task UpdateUser(User user)
    {
        User? existingUser = users.SingleOrDefault(u=> u.Id == user.Id);
        if (existingUser == null)
        {
            throw new InvalidOperationException($"User with id {user.Id} does not exist");
        }
        users.Remove(existingUser);
        users.Add(user);
        return Task.CompletedTask;
    }

    public Task RemoveUser(User user)
    {
        User? userToDelete = users.SingleOrDefault(u=> u.Id == user.Id);
        if (userToDelete == null)
        {
            throw new InvalidOperationException($"User with id {user.Id} does not exist");
        }
        users.Remove(userToDelete);
        return Task.CompletedTask;
    }

    public Task<User> GetUser(int userId)
    {
        User? user = users.SingleOrDefault(u=> u.Id == userId);
        if (user == null)
        {
            throw new InvalidOperationException($"User with id {userId} does not exist");
        }
        
        return Task.FromResult(user);
    }

    public IQueryable<User> GetUsers()
    {
        return users.AsQueryable();
    }
    
}
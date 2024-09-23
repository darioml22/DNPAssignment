using System.Text.Json;
using Entities;
using RepositoryContracts;

namespace InMemoryRepositories;

public class UserInMemoryRepository : IUserRepository
{
    private List<User> users = new List<User>();

    public async Task<User> AddUser(User user)
    {
        user.Id = users.Any()
            ? users.Max(u => u.Id) + 1
            : 1;
        users.Add(user);
        return await Task.FromResult(user);
    }

    public Task UpdateUser(User user)
    {
        User? existingUser = users.SingleOrDefault(u => u.Id == user.Id);
        if (existingUser == null)
        {
            throw new InvalidOperationException(
                $"User with id {user.Id} does not exist");
        }

        users.Remove(existingUser);
        users.Add(user);
        return Task.CompletedTask;
    }

    public Task RemoveUser(User user)
    {
        User? userToDelete = users.SingleOrDefault(u => u.Id == user.Id);
        if (userToDelete == null)
        {
            throw new InvalidOperationException(
                $"User with id {user.Id} does not exist");
        }

        users.Remove(userToDelete);
        return Task.CompletedTask;
    }

    public async Task<User> GetUser(int userId)
    {
        User? user = users.SingleOrDefault(u => u.Id == userId);
        if (user == null)
        {
            throw new InvalidOperationException(
                $"User with id {userId} does not exist");
        }

        return await Task.FromResult(user);
    }

    public IQueryable<User> GetUsers()
    {
        string usersAsJson = File.ReadAllTextAsync(filePath).Result;
        List<User> users =
            JsonSerializer.Deserialize<List<User>>(usersAsJson)!;
        return users.AsQueryable();
    }
}
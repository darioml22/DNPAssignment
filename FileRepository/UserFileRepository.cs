using System.Text.Json;
using Entities;
using RepositoryContracts;

namespace FileRepositories;

public class UserFileRepository : IUserRepository
{
    private readonly string filePath = "users.json";

    public UserFileRepository()
    {
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "[]");
        }
    }
    public async Task<User> AddUser(User user)
    {
        string usersAsJson = await File.ReadAllTextAsync(filePath);
        List<User> users = JsonSerializer.Deserialize<List<User>>(usersAsJson)!;
        int maxId = users != null && users.Count > 0 ? users.Max(x => x.Id) + 1 : 1;
        user.Id = maxId + 1;
        users?.Add(user);
        usersAsJson = JsonSerializer.Serialize(users);
        await File.WriteAllTextAsync(filePath, usersAsJson);
        return user;
    }

    public async Task UpdateUser(User user)
    {
        string usersAsJson = await File.ReadAllTextAsync(filePath);
        List<User> users = JsonSerializer.Deserialize<List<User>>(usersAsJson)!;
        User? existingUser = users.SingleOrDefault(c => c.Id == user.Id);
        if (existingUser == null)
        {
            throw new InvalidOperationException($"User with id {user.Id} does not exist");
        }
        users.Remove(existingUser);
        users.Add(user);
        usersAsJson = JsonSerializer.Serialize(users);
        await File.WriteAllTextAsync(filePath, usersAsJson);
    }

    public async Task RemoveUser(int id)
    {
        string usersAsJson = await File.ReadAllTextAsync(filePath);
        List<User> users = JsonSerializer.Deserialize<List<User>>(usersAsJson)!;
        User? userToDelete = users.SingleOrDefault(c => c.Id == id);
        if (userToDelete == null)
        {
            throw new InvalidOperationException($"User with id {id} does not exist");
        }
        users.Remove(userToDelete);
        usersAsJson = JsonSerializer.Serialize(users);
        await File.WriteAllTextAsync(filePath, usersAsJson);
    }

    public async Task<User> GetUser(int id)
    {
        string usersAsJson = await File.ReadAllTextAsync(filePath);
        List<User> users = JsonSerializer.Deserialize<List<User>>(usersAsJson)!;
        User? user = users.SingleOrDefault(c => c.Id == id);
        if (user == null)
        {
            throw new InvalidOperationException($"User with id {id} does not exist");
        }
        usersAsJson = JsonSerializer.Serialize(users);
        await File.WriteAllTextAsync(filePath, usersAsJson);
        return user;
    }

    public IQueryable<User> GetUsers()
    {
        string usersAsJson = File.ReadAllTextAsync(filePath).Result;
        List<User> users =
            JsonSerializer.Deserialize<List<User>>(usersAsJson)!;
        return users.AsQueryable();
    }
    
    public List<User> GetAll()
    {
        string usersAsJson = File.ReadAllTextAsync(filePath).Result;
        List<User> users =
            JsonSerializer.Deserialize<List<User>>(usersAsJson)!;
        return users;

    }
}
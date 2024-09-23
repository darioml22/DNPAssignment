using Entities;
using RepositoryContracts;

namespace CLI.UI.ManageUsers;

public class AddUserView
{
    public readonly IUserRepository userRepository;

    public AddUserView(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    /*public async Task<User> AddUser()
    {
        User user = new User();
        Console.WriteLine("Enter username");
        user.Username = Console.ReadLine();
        Console.WriteLine("Enter password");
        user.Password = Console.ReadLine();
        return await userRepository.AddUser(user);
    }*/
}
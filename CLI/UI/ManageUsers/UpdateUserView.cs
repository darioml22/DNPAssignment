using Entities;
using RepositoryContracts;

namespace CLI.UI.ManageUsers;

public class UpdateUserView
{
    public readonly IUserRepository userRepository;
    CliApp cliApp;

    public UpdateUserView(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
        
    }
    
    public void UpdateUser(User user)
    {
        Console.WriteLine("Enter user id");
        user.Id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter a new user name");
        user.Username = Console.ReadLine();
        Console.WriteLine("Enter a new password");
        user.Username = Console.ReadLine();
        userRepository.UpdateUser(user);
    }
}
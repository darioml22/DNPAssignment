using Entities;
using RepositoryContracts;

namespace CLI.UI.ManageUsers;

public class DeleteUserView
{
    public readonly IUserRepository userRepository;
    CliApp cliApp;

    public DeleteUserView(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
        
    }
    
    public void DeleteUser(User user)
    {
        Console.WriteLine("Enter user id");
        user.Id = Convert.ToInt32(Console.ReadLine());
        userRepository.RemoveUser(user);
        Console.WriteLine("User deleted");
    }
}
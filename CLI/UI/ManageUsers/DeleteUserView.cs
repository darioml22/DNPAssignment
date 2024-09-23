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
    
    public void DeleteUser(int id)
    {
        Console.WriteLine("Enter user id");
        id = Convert.ToInt32(Console.ReadLine());
        userRepository.RemoveUser(id);
        Console.WriteLine("User deleted");
    }
}
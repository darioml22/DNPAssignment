using Entities;
using RepositoryContracts;

namespace CLI.UI.ManageUsers;

public class GetUserView
{
    public readonly IUserRepository userRepository;
    CliApp cliApp;

    public GetUserView(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
        
    }
    
    public void GetUser(User user)
    {
        Console.WriteLine("Enter user id");
        user.Id = Convert.ToInt32(Console.ReadLine());
        userRepository.GetUser(user.Id);
    }
}
using Entities;
using RepositoryContracts;

namespace CLI.UI.ManagePosts;

public class DeletePostView
{
    public readonly IPostRepository postRepository;
    CliApp cliApp;

    public DeletePostView(IPostRepository postRepository)
    {
        this.postRepository = postRepository;
        
    }
    
    public void DeletePost(int id)
    {
        Console.WriteLine("Enter post id");
        id = Convert.ToInt32(Console.ReadLine());
        postRepository.DeletePost(id);
        Console.WriteLine("Post deleted");
    }
}
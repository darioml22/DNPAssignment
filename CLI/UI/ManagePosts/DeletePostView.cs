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
    
    public void DeletePost(Post post)
    {
        Console.WriteLine("Enter post id");
        post.Id = Convert.ToInt32(Console.ReadLine());
        postRepository.DeletePost(post);
        Console.WriteLine("Post deleted");
        cliApp.StartAsync();
    }
}
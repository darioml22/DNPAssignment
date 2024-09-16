using Entities;
using RepositoryContracts;

namespace CLI.UI.ManagePosts;

public class GetPostView
{
    public readonly IPostRepository postRepository;
    CliApp cliApp;

    public GetPostView(IPostRepository postRepository)
    {
        this.postRepository = postRepository;
        
    }
    
    public void GetPost(Post post)
    {
        Console.WriteLine("Enter post id");
        post.Id = Convert.ToInt32(Console.ReadLine());
        postRepository.GetPost(post.Id);
    }
}
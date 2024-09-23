using Entities;
using RepositoryContracts;

namespace CLI.UI.ManagePosts;

public class AddPostView
{
    public readonly IPostRepository postRepository;

    public AddPostView(IPostRepository postRepository)
    {
        this.postRepository = postRepository;
        
    }
    
    /*public async Task<Post> AddPost()
    {
        Post post = new Post();
        Console.WriteLine("Enter post title");
        post.Title = Console.ReadLine();
        Console.WriteLine("Enter post content");
        post.Content = Console.ReadLine();
        return await postRepository.AddPost(post);
    }*/
}